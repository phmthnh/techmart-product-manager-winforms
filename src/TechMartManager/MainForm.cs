using System.ComponentModel;
using System.Globalization;
using System.Text;
using TechMartManager.Helpers;
using TechMartManager.Models;

namespace TechMartManager
{

public partial class MainForm : Form
{
    // ── Data ────────────────────────────────────────────────────────────────
    private readonly BindingList<Product> _allProducts = new();
    private readonly BindingSource _bindingSource = new();
    private bool _isEditing = false;   // đang sửa → khóa txtProductId

    public MainForm()
    {
        InitializeComponent();
        SetupDataBinding();
        LoadSampleData();
    }

    // ── Khởi tạo Data Binding ────────────────────────────────────────────────
    private void SetupDataBinding()
    {
        // ComboBox danh mục — gán DisplayMember / ValueMember
        var categories = new List<CategoryItem>
        {
            new() { Id = 1, Name = "Điện thoại" },
            new() { Id = 2, Name = "Laptop"     },
            new() { Id = 3, Name = "Phụ kiện"   },
        };
        cboCategory.DataSource    = categories;
        cboCategory.DisplayMember = "Name";
        cboCategory.ValueMember   = "Id";

        // DataGridView dùng BindingSource làm trung gian
        _bindingSource.DataSource = _allProducts;
        dgvProducts.DataSource    = _bindingSource;

        UpdateStatus();
    }

    // ── Dữ liệu mẫu ─────────────────────────────────────────────────────────
    private void LoadSampleData()
    {
        _allProducts.Add(new Product { ProductId = "SP001", ProductName = "iPhone 15 Pro", Category = "Điện thoại", UnitPrice = 29_990_000, Quantity = 10 });
        _allProducts.Add(new Product { ProductId = "SP002", ProductName = "Laptop Dell XPS 15", Category = "Laptop",    UnitPrice = 45_000_000, Quantity = 5  });
        _allProducts.Add(new Product { ProductId = "SP003", ProductName = "Tai nghe AirPods Pro", Category = "Phụ kiện",  UnitPrice = 6_500_000,  Quantity = 20 });
        AppHelpers.ResetIdCounter(4);
        UpdateStatus();
    }

    // ── Nút Thêm mới ─────────────────────────────────────────────────────────
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        string id = string.IsNullOrWhiteSpace(txtProductId.Text)
            ? AppHelpers.GenerateProductId()
            : txtProductId.Text.Trim();

        // Kiểm tra mã trùng
        if (_allProducts.Any(p => p.ProductId == id))
        {
            errorProvider.SetError(txtProductId, "Mã sản phẩm đã tồn tại!");
            return;
        }

        _allProducts.Add(new Product
        {
            ProductId   = id,
            ProductName = txtProductName.Text.Trim(),
            Category    = (cboCategory.SelectedItem as CategoryItem)?.Name ?? "",
            UnitPrice   = AppHelpers.ParsePrice(txtUnitPrice.Text) ?? 0,
            Quantity    = int.Parse(txtQuantity.Text.Trim()),
            ImagePath   = picAvatar.Tag?.ToString()
        });

        ClearForm();
        UpdateStatus();
    }

    // ── Nút Cập nhật ─────────────────────────────────────────────────────────
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một dòng để cập nhật!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!ValidateInputs()) return;

        var product = _allProducts[_bindingSource.Position];
        product.ProductName = txtProductName.Text.Trim();
        product.Category    = (cboCategory.SelectedItem as CategoryItem)?.Name ?? "";
        product.UnitPrice   = AppHelpers.ParsePrice(txtUnitPrice.Text) ?? 0;
        product.Quantity    = int.Parse(txtQuantity.Text.Trim());
        product.ImagePath   = picAvatar.Tag?.ToString();

        _bindingSource.ResetCurrentItem();
        _isEditing = false;
        txtProductId.ReadOnly = false;
        ClearForm();
    }

    // ── Nút Xóa ──────────────────────────────────────────────────────────────
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // TC05: xác nhận Yes/No với Icon Question
        var confirm = MessageBox.Show(
            "Bạn có chắc muốn xóa sản phẩm này?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            _allProducts.RemoveAt(_bindingSource.Position);
            ClearForm();
            UpdateStatus();
        }
    }

    // ── Nút Xóa form ─────────────────────────────────────────────────────────
    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    // ── Nút Chọn ảnh ─────────────────────────────────────────────────────────
    private void btnChooseImage_Click(object sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title  = "Chọn ảnh đại diện sản phẩm",
            Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.webp|Tất cả|*.*"
        };

        if (dlg.ShowDialog() != DialogResult.OK) return;

        try
        {
            // Dùng FileStream + Bitmap để không khóa file gốc
            using var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            var bmp = new Bitmap(fs);

            picAvatar.Image?.Dispose();   // giải phóng ảnh cũ
            picAvatar.Image = bmp;
            picAvatar.Tag   = dlg.FileName;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không thể tải ảnh: {ex.Message}", "Lỗi ảnh",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ── Live search ───────────────────────────────────────────────────────────
    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string keyword = txtSearch.Text.Trim();
        var filtered   = _allProducts
            .Where(p => AppHelpers.MatchesSearch(p.ProductName, keyword))
            .ToList();

        // Tạm thời đổi datasource để không mất dữ liệu gốc
        _bindingSource.DataSource = new BindingList<Product>(filtered);
        dgvProducts.DataSource    = _bindingSource;
    }

    // ── Click chọn dòng → nạp ngược lên form ─────────────────────────────────
    private void dgvProducts_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow == null) return;
        // Khi đang gõ search, tránh ghi đè dữ liệu người dùng
        if (!string.IsNullOrWhiteSpace(txtSearch.Text)) return;

        // Lấy từ BindingSource hiện tại
        if (_bindingSource.Current is not Product p) return;

        txtProductId.Text   = p.ProductId;
        txtProductName.Text = p.ProductName;
        txtUnitPrice.Text   = p.UnitPrice.ToString("N0", CultureInfo.InvariantCulture);
        txtQuantity.Text    = p.Quantity.ToString();

        // Chọn đúng danh mục trong ComboBox
        var cat = (cboCategory.DataSource as List<CategoryItem>)?
            .FirstOrDefault(c => c.Name == p.Category);
        if (cat != null) cboCategory.SelectedItem = cat;

        // Nạp ảnh nếu có
        if (!string.IsNullOrEmpty(p.ImagePath) && File.Exists(p.ImagePath))
        {
            try
            {
                using var fs = new FileStream(p.ImagePath, FileMode.Open, FileAccess.Read);
                picAvatar.Image?.Dispose();
                picAvatar.Image = new Bitmap(fs);
                picAvatar.Tag   = p.ImagePath;
            }
            catch { /* bỏ qua nếu file ảnh bị xóa */ }
        }

        _isEditing = true;
        txtProductId.ReadOnly = true;   // không cho đổi mã khi đang sửa
    }

    // ── Menu: Export CSV ─────────────────────────────────────────────────────
    private void menuExportCsv_Click(object sender, EventArgs e) => ExportCsv();

    private void btnExportCsv_Click(object sender, EventArgs e) => ExportCsv();

    private void ExportCsv()
    {
        using var dlg = new SaveFileDialog
        {
            Title      = "Xuất danh sách sản phẩm",
            Filter     = "CSV|*.csv",
            FileName   = "techmart_products.csv",
            DefaultExt = "csv"
        };

        if (dlg.ShowDialog() != DialogResult.OK) return;

        try
        {
            string content = AppHelpers.BuildCsvContent(_allProducts);
            // Ghi UTF-8 có BOM để Excel đọc đúng tiếng Việt
            File.WriteAllText(dlg.FileName, content, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
            MessageBox.Show($"Xuất CSV thành công:\n{dlg.FileName}", "Hoàn tất",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (IOException ex)
        {
            MessageBox.Show($"Lỗi ghi file: {ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Không có quyền ghi vào vị trí này.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ── Menu: Exit ───────────────────────────────────────────────────────────
    private void menuExit_Click(object sender, EventArgs e) => Application.Exit();

    // ── Validation ───────────────────────────────────────────────────────────
    private bool ValidateInputs()
    {
        bool ok = true;
        errorProvider.Clear();

        if (string.IsNullOrWhiteSpace(txtProductName.Text))
        {
            errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống!");
            ok = false;
        }

        var price = AppHelpers.ParsePrice(txtUnitPrice.Text);
        if (price == null || price <= 0)
        {
            errorProvider.SetError(txtUnitPrice, "Đơn giá phải lớn hơn 0!");
            ok = false;
        }

        if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty < 0)
        {
            errorProvider.SetError(txtQuantity, "Số lượng phải là số nguyên ≥ 0!");
            ok = false;
        }

        return ok;
    }

    // ── Xóa form nhập liệu ──────────────────────────────────────────────────
    private void ClearForm()
    {
        errorProvider.Clear();
        txtProductId.Text   = string.Empty;
        txtProductName.Text = string.Empty;
        txtUnitPrice.Text   = string.Empty;
        txtQuantity.Text    = string.Empty;
        cboCategory.SelectedIndex = 0;
        picAvatar.Image?.Dispose();
        picAvatar.Image = null;
        picAvatar.Tag   = null;
        txtProductId.ReadOnly = false;
        _isEditing = false;

        // Khôi phục toàn bộ danh sách khi xóa form (reset search)
        if (!string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            txtSearch.Text = string.Empty;
        }
        else
        {
            _bindingSource.DataSource = _allProducts;
            dgvProducts.DataSource    = _bindingSource;
        }
    }

    // ── Cập nhật StatusStrip ─────────────────────────────────────────────────
    private void UpdateStatus() =>
        lblStatus.Text = $"Tổng số sản phẩm: {_allProducts.Count}";
}

}
