using System.Globalization;
using TechMartManager.Models;

namespace TechMartManager;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        // ── Controls ─────────────────────────────────────────────────────────
        this.tableMain      = new System.Windows.Forms.TableLayoutPanel();
        this.pnlLeft        = new System.Windows.Forms.Panel();
        this.grpInput       = new System.Windows.Forms.GroupBox();
        this.lblProductId   = new System.Windows.Forms.Label();
        this.txtProductId   = new System.Windows.Forms.TextBox();
        this.lblProductName = new System.Windows.Forms.Label();
        this.txtProductName = new System.Windows.Forms.TextBox();
        this.lblCategory    = new System.Windows.Forms.Label();
        this.cboCategory    = new System.Windows.Forms.ComboBox();
        this.lblUnitPrice   = new System.Windows.Forms.Label();
        this.txtUnitPrice   = new System.Windows.Forms.TextBox();
        this.lblQuantity    = new System.Windows.Forms.Label();
        this.txtQuantity    = new System.Windows.Forms.TextBox();
        this.lblAvatar      = new System.Windows.Forms.Label();
        this.picAvatar      = new System.Windows.Forms.PictureBox();
        this.btnChooseImage = new System.Windows.Forms.Button();
        this.pnlActionBtns  = new System.Windows.Forms.Panel();
        this.btnAdd         = new System.Windows.Forms.Button();
        this.btnUpdate      = new System.Windows.Forms.Button();
        this.btnDelete      = new System.Windows.Forms.Button();
        this.btnClear       = new System.Windows.Forms.Button();
        this.btnExportCsv   = new System.Windows.Forms.Button();
        this.errorProvider  = new System.Windows.Forms.ErrorProvider(this.components);
        this.pnlRight       = new System.Windows.Forms.Panel();
        this.txtSearch      = new System.Windows.Forms.TextBox();
        this.lblSearch      = new System.Windows.Forms.Label();
        this.dgvProducts    = new System.Windows.Forms.DataGridView();
        this.colId          = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colName        = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colCategory    = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPrice       = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colQty         = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.menuStrip      = new System.Windows.Forms.MenuStrip();
        this.menuFile       = new System.Windows.Forms.ToolStripMenuItem();
        this.menuExportCsv  = new System.Windows.Forms.ToolStripMenuItem();
        this.menuExit       = new System.Windows.Forms.ToolStripMenuItem();
        this.statusStrip    = new System.Windows.Forms.StatusStrip();
        this.lblStatus      = new System.Windows.Forms.ToolStripStatusLabel();

        // Begin init
        this.tableMain.SuspendLayout();
        this.pnlLeft.SuspendLayout();
        this.grpInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
        this.pnlActionBtns.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        this.pnlRight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
        this.menuStrip.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        // ── menuStrip ────────────────────────────────────────────────────────
        this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuFile });
        this.menuStrip.Location = new System.Drawing.Point(0, 0);
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Size = new System.Drawing.Size(1100, 24);

        // menuFile
        this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuExportCsv, this.menuExit });
        this.menuFile.Name = "menuFile";
        this.menuFile.Text = "File";

        // menuExportCsv
        this.menuExportCsv.Name = "menuExportCsv";
        this.menuExportCsv.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E;
        this.menuExportCsv.Text = "Xuất CSV";
        this.menuExportCsv.Click += new System.EventHandler(this.menuExportCsv_Click);

        // menuExit
        this.menuExit.Name = "menuExit";
        this.menuExit.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
        this.menuExit.Text = "Thoát";
        this.menuExit.Click += new System.EventHandler(this.menuExit_Click);

        // ── statusStrip ──────────────────────────────────────────────────────
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
        this.statusStrip.Location = new System.Drawing.Point(0, 628);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(1100, 22);

        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Text = "Tổng số sản phẩm: 0";

        // ── tableMain (layout chính 35% / 65%) ───────────────────────────────
        this.tableMain.ColumnCount = 2;
        this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
        this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
        this.tableMain.RowCount = 1;
        this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableMain.Controls.Add(this.pnlLeft,  0, 0);
        this.tableMain.Controls.Add(this.pnlRight, 1, 0);
        this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableMain.Location = new System.Drawing.Point(0, 24);
        this.tableMain.Name = "tableMain";
        this.tableMain.Size = new System.Drawing.Size(1100, 604);
        this.tableMain.TabIndex = 0;

        // ── pnlLeft ───────────────────────────────────────────────────────────
        this.pnlLeft.Controls.Add(this.grpInput);
        this.pnlLeft.Controls.Add(this.pnlActionBtns);
        this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlLeft.Padding = new System.Windows.Forms.Padding(8);
        this.pnlLeft.Name = "pnlLeft";

        // ── grpInput ─────────────────────────────────────────────────────────
        this.grpInput.Controls.Add(this.lblProductId);
        this.grpInput.Controls.Add(this.txtProductId);
        this.grpInput.Controls.Add(this.lblProductName);
        this.grpInput.Controls.Add(this.txtProductName);
        this.grpInput.Controls.Add(this.lblCategory);
        this.grpInput.Controls.Add(this.cboCategory);
        this.grpInput.Controls.Add(this.lblUnitPrice);
        this.grpInput.Controls.Add(this.txtUnitPrice);
        this.grpInput.Controls.Add(this.lblQuantity);
        this.grpInput.Controls.Add(this.txtQuantity);
        this.grpInput.Controls.Add(this.lblAvatar);
        this.grpInput.Controls.Add(this.picAvatar);
        this.grpInput.Controls.Add(this.btnChooseImage);
        this.grpInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.grpInput.Location = new System.Drawing.Point(8, 8);
        this.grpInput.Name = "grpInput";
        this.grpInput.Size = new System.Drawing.Size(362, 490);
        this.grpInput.TabIndex = 0;
        this.grpInput.TabStop = false;
        this.grpInput.Text = "Thông Tin Sản Phẩm";

        // Mã SP
        this.lblProductId.Text = "Mã SP:";
        this.lblProductId.Location = new System.Drawing.Point(12, 28);
        this.lblProductId.Size = new System.Drawing.Size(80, 20);
        this.lblProductId.TabIndex = 0;

        this.txtProductId.Location = new System.Drawing.Point(100, 25);
        this.txtProductId.Name = "txtProductId";
        this.txtProductId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.txtProductId.Size = new System.Drawing.Size(248, 23);
        this.txtProductId.PlaceholderText = "Để trống → tự sinh mã";
        this.txtProductId.TabIndex = 1;

        // Tên SP
        this.lblProductName.Text = "Tên SP:";
        this.lblProductName.Location = new System.Drawing.Point(12, 63);
        this.lblProductName.Size = new System.Drawing.Size(80, 20);
        this.lblProductName.TabIndex = 2;

        this.txtProductName.Location = new System.Drawing.Point(100, 60);
        this.txtProductName.Name = "txtProductName";
        this.txtProductName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.txtProductName.Size = new System.Drawing.Size(248, 23);
        this.txtProductName.TabIndex = 3;

        // Danh mục
        this.lblCategory.Text = "Danh mục:";
        this.lblCategory.Location = new System.Drawing.Point(12, 98);
        this.lblCategory.Size = new System.Drawing.Size(80, 20);
        this.lblCategory.TabIndex = 4;

        this.cboCategory.Location = new System.Drawing.Point(100, 95);
        this.cboCategory.Name = "cboCategory";
        this.cboCategory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.cboCategory.Size = new System.Drawing.Size(248, 23);
        this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboCategory.TabIndex = 5;

        // Đơn giá
        this.lblUnitPrice.Text = "Đơn giá (VNĐ):";
        this.lblUnitPrice.Location = new System.Drawing.Point(12, 133);
        this.lblUnitPrice.Size = new System.Drawing.Size(95, 20);
        this.lblUnitPrice.TabIndex = 6;

        this.txtUnitPrice.Location = new System.Drawing.Point(100, 130);
        this.txtUnitPrice.Name = "txtUnitPrice";
        this.txtUnitPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.txtUnitPrice.Size = new System.Drawing.Size(248, 23);
        this.txtUnitPrice.TabIndex = 7;

        // Số lượng
        this.lblQuantity.Text = "Số lượng:";
        this.lblQuantity.Location = new System.Drawing.Point(12, 168);
        this.lblQuantity.Size = new System.Drawing.Size(80, 20);
        this.lblQuantity.TabIndex = 8;

        this.txtQuantity.Location = new System.Drawing.Point(100, 165);
        this.txtQuantity.Name = "txtQuantity";
        this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.txtQuantity.Size = new System.Drawing.Size(248, 23);
        this.txtQuantity.TabIndex = 9;

        // Ảnh đại diện
        this.lblAvatar.Text = "Ảnh SP:";
        this.lblAvatar.Location = new System.Drawing.Point(12, 205);
        this.lblAvatar.Size = new System.Drawing.Size(80, 20);
        this.lblAvatar.TabIndex = 10;

        this.picAvatar.Location = new System.Drawing.Point(12, 230);
        this.picAvatar.Name = "picAvatar";
        this.picAvatar.Size = new System.Drawing.Size(200, 160);
        this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.picAvatar.TabIndex = 11;

        this.btnChooseImage.Text = "Chọn Ảnh";
        this.btnChooseImage.Name = "btnChooseImage";
        this.btnChooseImage.Location = new System.Drawing.Point(220, 355);
        this.btnChooseImage.Size = new System.Drawing.Size(130, 30);
        this.btnChooseImage.BackColor = System.Drawing.Color.FromArgb(100, 100, 180);
        this.btnChooseImage.ForeColor = System.Drawing.Color.White;
        this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnChooseImage.TabIndex = 12;
        this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);

        // ── pnlActionBtns ────────────────────────────────────────────────────
        this.pnlActionBtns.Controls.Add(this.btnAdd);
        this.pnlActionBtns.Controls.Add(this.btnUpdate);
        this.pnlActionBtns.Controls.Add(this.btnDelete);
        this.pnlActionBtns.Controls.Add(this.btnClear);
        this.pnlActionBtns.Controls.Add(this.btnExportCsv);
        this.pnlActionBtns.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.pnlActionBtns.Location = new System.Drawing.Point(8, 505);
        this.pnlActionBtns.Name = "pnlActionBtns";
        this.pnlActionBtns.Size = new System.Drawing.Size(362, 85);
        this.pnlActionBtns.TabIndex = 1;

        // btnAdd
        this.btnAdd.Text = "Thêm mới";
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Location = new System.Drawing.Point(0, 5);
        this.btnAdd.Size = new System.Drawing.Size(100, 35);
        this.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 150, 100);
        this.btnAdd.ForeColor = System.Drawing.Color.White;
        this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAdd.TabIndex = 0;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        // btnUpdate
        this.btnUpdate.Text = "Cập nhật";
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Location = new System.Drawing.Point(108, 5);
        this.btnUpdate.Size = new System.Drawing.Size(100, 35);
        this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnUpdate.ForeColor = System.Drawing.Color.White;
        this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnUpdate.TabIndex = 1;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

        // btnDelete
        this.btnDelete.Text = "Xóa";
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Location = new System.Drawing.Point(216, 5);
        this.btnDelete.Size = new System.Drawing.Size(100, 35);
        this.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
        this.btnDelete.ForeColor = System.Drawing.Color.White;
        this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDelete.TabIndex = 2;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        // btnClear
        this.btnClear.Text = "Xóa form";
        this.btnClear.Name = "btnClear";
        this.btnClear.Location = new System.Drawing.Point(0, 45);
        this.btnClear.Size = new System.Drawing.Size(100, 35);
        this.btnClear.BackColor = System.Drawing.Color.FromArgb(120, 100, 120);
        this.btnClear.ForeColor = System.Drawing.Color.White;
        this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClear.TabIndex = 3;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

        // btnExportCsv
        this.btnExportCsv.Text = "Xuất CSV";
        this.btnExportCsv.Name = "btnExportCsv";
        this.btnExportCsv.Location = new System.Drawing.Point(108, 45);
        this.btnExportCsv.Size = new System.Drawing.Size(100, 35);
        this.btnExportCsv.BackColor = System.Drawing.Color.FromArgb(180, 120, 0);
        this.btnExportCsv.ForeColor = System.Drawing.Color.White;
        this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnExportCsv.TabIndex = 4;
        this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);

        // ── errorProvider ────────────────────────────────────────────────────
        this.errorProvider.ContainerControl = this;

        // ── pnlRight ─────────────────────────────────────────────────────────
        this.pnlRight.Controls.Add(this.lblSearch);
        this.pnlRight.Controls.Add(this.txtSearch);
        this.pnlRight.Controls.Add(this.dgvProducts);
        this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlRight.Padding = new System.Windows.Forms.Padding(8);
        this.pnlRight.Name = "pnlRight";

        // lblSearch
        this.lblSearch.Text = "🔍 Tìm kiếm:";
        this.lblSearch.Location = new System.Drawing.Point(8, 15);
        this.lblSearch.Size = new System.Drawing.Size(90, 23);
        this.lblSearch.TabIndex = 0;

        // txtSearch
        this.txtSearch.Location = new System.Drawing.Point(105, 12);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.txtSearch.Size = new System.Drawing.Size(590, 23);
        this.txtSearch.PlaceholderText = "Nhập tên sản phẩm để lọc...";
        this.txtSearch.TabIndex = 1;
        this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

        // dgvProducts
        this.dgvProducts.Name = "dgvProducts";
        this.dgvProducts.Location = new System.Drawing.Point(8, 45);
        this.dgvProducts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.dgvProducts.Size = new System.Drawing.Size(690, 545);
        this.dgvProducts.AutoGenerateColumns = false;
        this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvProducts.AllowUserToAddRows = false;
        this.dgvProducts.ReadOnly = true;
        this.dgvProducts.RowHeadersVisible = false;
        this.dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 255);
        this.dgvProducts.TabIndex = 2;
        this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);

        // Các cột DataGridView
        this.colId.DataPropertyName = "ProductId";
        this.colId.HeaderText = "Mã SP";
        this.colId.Width = 80;

        this.colName.DataPropertyName = "ProductName";
        this.colName.HeaderText = "Tên Sản Phẩm";
        this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

        this.colCategory.DataPropertyName = "Category";
        this.colCategory.HeaderText = "Danh Mục";
        this.colCategory.Width = 120;

        this.colPrice.DataPropertyName = "UnitPrice";
        this.colPrice.HeaderText = "Đơn Giá (VNĐ)";
        this.colPrice.Width = 130;
        this.colPrice.DefaultCellStyle.Format = "N0";
        this.colPrice.DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.InvariantCulture;
        this.colPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

        this.colQty.DataPropertyName = "Quantity";
        this.colQty.HeaderText = "Số Lượng";
        this.colQty.Width = 85;
        this.colQty.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

        this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
        {
            this.colId, this.colName, this.colCategory, this.colPrice, this.colQty
        });

        // ── MainForm ─────────────────────────────────────────────────────────
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1100, 650);
        this.MinimumSize = new System.Drawing.Size(800, 550);
        this.Controls.Add(this.tableMain);
        this.Controls.Add(this.menuStrip);
        this.Controls.Add(this.statusStrip);
        this.MainMenuStrip = this.menuStrip;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "TechMart Product Manager";

        // End init
        this.tableMain.ResumeLayout(false);
        this.pnlLeft.ResumeLayout(false);
        this.grpInput.ResumeLayout(false);
        this.grpInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
        this.pnlActionBtns.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        this.pnlRight.ResumeLayout(false);
        this.pnlRight.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    // ── Field declarations ──────────────────────────────────────────────────
    private System.Windows.Forms.TableLayoutPanel tableMain;
    private System.Windows.Forms.Panel pnlLeft;
    private System.Windows.Forms.GroupBox grpInput;
    private System.Windows.Forms.Label lblProductId;
    private System.Windows.Forms.TextBox txtProductId;
    private System.Windows.Forms.Label lblProductName;
    private System.Windows.Forms.TextBox txtProductName;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.ComboBox cboCategory;
    private System.Windows.Forms.Label lblUnitPrice;
    private System.Windows.Forms.TextBox txtUnitPrice;
    private System.Windows.Forms.Label lblQuantity;
    private System.Windows.Forms.TextBox txtQuantity;
    private System.Windows.Forms.Label lblAvatar;
    private System.Windows.Forms.PictureBox picAvatar;
    private System.Windows.Forms.Button btnChooseImage;
    private System.Windows.Forms.Panel pnlActionBtns;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnExportCsv;
    private System.Windows.Forms.ErrorProvider errorProvider;
    private System.Windows.Forms.Panel pnlRight;
    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.DataGridView dgvProducts;
    private System.Windows.Forms.DataGridViewTextBoxColumn colId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem menuExportCsv;
    private System.Windows.Forms.ToolStripMenuItem menuExit;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
}
