# 🛒 TechMart Product Manager — Quản lý Thiết bị Công nghệ

> **Bài Kiểm Tra 01 — Phần III: Windows Forms GUI**
> Môn: Lập trình C# / .NET | Sinh viên: Phạm Tuấn Thành | Công nghệ: .NET 8 · WinForms

---

## 📋 Mô tả bài toán

Ứng dụng quản lý danh mục sản phẩm công nghệ cho chuỗi **TechMart**, cho phép thêm/sửa/xóa sản phẩm, tìm kiếm real-time, nạp ảnh đại diện và xuất dữ liệu ra file CSV.

---

## 🖼️ Bố cục giao diện (35% / 65%)

```
┌─────────────────────────────────────────────────────────────────┐
│  MenuStrip: File → [Xuất CSV Ctrl+E]  [Thoát Ctrl+X]           │
├──────────────────────────┬──────────────────────────────────────┤
│  Cột trái 35%            │  Cột phải 65%                        │
│  ┌─────────────────────┐ │  🔍 [txtSearch_______________]       │
│  │ Thông Tin Sản Phẩm  │ │  ┌────────────────────────────────┐ │
│  │ Mã SP: [txtProductId│ │  │ Mã SP │ Tên SP │ DM │ Giá │ SL│ │
│  │ Tên SP:[txtProductNa│ │  │ SP001 │ iPhone │ ĐT │ 29..│ 10│ │
│  │ DM:    [cboCategory │ │  │ SP002 │ Dell   │ LP │ 45..│  5│ │
│  │ Giá:   [txtUnitPrice│ │  │ ...   │ ...    │ .. │ ... │...│ │
│  │ SL:    [txtQuantity │ │  └────────────────────────────────┘ │
│  │ Ảnh:  [picAvatar]   │ │                                      │
│  │       [Chọn Ảnh]    │ │                                      │
│  └─────────────────────┘ │                                      │
│  [Thêm] [Cập nhật] [Xóa] │                                      │
│  [Xóa form]  [Xuất CSV]  │                                      │
├──────────────────────────┴──────────────────────────────────────┤
│  StatusStrip: Tổng số sản phẩm: 3                               │
└─────────────────────────────────────────────────────────────────┘
```

---

## 🗂️ Cấu trúc thư mục

```
techmart-product-manager-winforms/
├── .gitignore
├── TechMartManager.sln
├── src/
│   └── TechMartManager/
│       ├── TechMartManager.csproj     # net8.0-windows, UseWindowsForms
│       ├── Program.cs                 # Entry point [STAThread]
│       ├── MainForm.cs                # Business logic: thêm/sửa/xóa/search/CSV
│       ├── MainForm.Designer.cs       # UI: InitializeComponent đầy đủ literal values
│       ├── Models/
│       │   ├── Product.cs             # Model sản phẩm
│       │   └── CategoryItem.cs        # Model danh mục (ComboBox binding)
│       └── Helpers/
│           └── AppHelpers.cs          # ParsePrice, BuildCsvContent, MatchesSearch, GenerateId
└── docs/
    ├── TESTING.md                     # Checklist kiểm thử thủ công TC01..TC05
    └── screenshots/                   # Đặt ảnh chụp màn hình vào đây
```

---

## 📐 Bảng truy vết yêu cầu

| Mã YC | Nội dung yêu cầu | File / Thành phần | Trạng thái |
|-------|-----------------|-------------------|-----------|
| R-GUI-01 | `TableLayoutPanel` 35%/65%, `Dock = Fill` | `MainForm.Designer.cs` | ✅ Đạt |
| R-GUI-02 | `Anchor`/`Dock` hợp lý, responsive khi Maximize | Designer, tất cả controls | ✅ Đạt |
| R-GUI-03 | `txtProductId`, `txtProductName`, `txtUnitPrice`, `txtQuantity` | Designer | ✅ Đạt |
| R-GUI-04 | `cboCategory` với `DisplayMember`/`ValueMember` | `MainForm.cs` SetupDataBinding | ✅ Đạt |
| R-GUI-05 | `picAvatar` `SizeMode = Zoom`, nút `btnChooseImage` | Designer | ✅ Đạt |
| R-GUI-06 | `errorProvider` validate Tên SP, Đơn giá > 0, SL ≥ 0 | `MainForm.cs` ValidateInputs | ✅ Đạt |
| R-GUI-07 | `dgvProducts` `AutoGenerateColumns = false`, `FullRowSelect` | Designer | ✅ Đạt |
| R-GUI-08 | 5 cột tự định nghĩa, Đơn giá `Format "N0"` | Designer colPrice | ✅ Đạt |
| R-GUI-09 | `BindingSource` + `BindingList<Product>` | `MainForm.cs` | ✅ Đạt |
| R-GUI-10 | Click dòng → nạp ngược lên form | `dgvProducts_SelectionChanged` | ✅ Đạt |
| R-GUI-11 | `MenuStrip` File → Export CSV (Ctrl+E), Exit (Ctrl+X) | Designer | ✅ Đạt |
| R-GUI-12 | `StatusStrip` "Tổng số sản phẩm: X" | Designer + UpdateStatus() | ✅ Đạt |
| R-GUI-13 | Thêm mới với validation | `btnAdd_Click` | ✅ Đạt |
| R-GUI-14 | Cập nhật sản phẩm đang chọn | `btnUpdate_Click` | ✅ Đạt |
| R-GUI-15 | Xóa có xác nhận Yes/No Question | `btnDelete_Click` | ✅ Đạt |
| R-GUI-16 | Tìm kiếm real-time `TextChanged` | `txtSearch_TextChanged` | ✅ Đạt |
| R-GUI-17 | Xuất CSV `SaveFileDialog`, UTF-8 BOM | `ExportCsv()`, `AppHelpers.BuildCsvContent` | ✅ Đạt |

---

## 🧪 Kết quả kiểm thử

| TC | Kịch bản | Kết quả kỳ vọng | Trạng thái |
|----|----------|-----------------|-----------|
| TC01 | Responsive Maximize | TableLayoutPanel 35/65 co giãn đúng | Chưa kiểm thử thủ công |
| TC02 | Validation ErrorProvider | 2 icon lỗi đồng thời, không thêm | Chưa kiểm thử thủ công |
| TC03 | Data Binding & Format | Giá hiển thị `25,000,000` | Chưa kiểm thử thủ công |
| TC04 | Nạp ảnh OpenFileDialog | Ảnh hiện Zoom trong PictureBox | Chưa kiểm thử thủ công |
| TC05 | Xóa với Yes/No Question | Chọn Yes → xóa, No → giữ nguyên | Chưa kiểm thử thủ công |

> 📌 Xem checklist chi tiết tại [docs/TESTING.md](docs/TESTING.md) để tự tick kết quả sau khi chạy thử.

---

## 🚀 Cách chạy

> ⚠️ **Bắt buộc chạy trên Windows** (WinForms không hỗ trợ Linux/macOS).

```bash
# Yêu cầu: .NET 8 SDK + Windows
dotnet run --project src/TechMartManager
```

Mở bằng **Visual Studio 2022**: mở file `TechMartManager.sln`.

---

## 💡 Giả định & Quyết định thiết kế

| Điểm mơ hồ | Cách xử lý |
|------------|-----------|
| `txtProductId` để trống khi thêm | Tự sinh mã `SP001`, `SP002`, ... |
| Đơn giá chấp nhận định dạng nào | Chấp nhận `25000000`, `25,000,000`, `25.000.000` |
| Ctrl+X trùng phím Cut | Làm đúng đề; ghi rõ: nếu bị trừ điểm có thể đổi sang Ctrl+Q |
| Cột Đơn giá format "N0" | Dùng `InvariantCulture` → luôn dấu phẩy bất kể cài đặt máy |
| Ảnh bị khóa file | Copy sang `Bitmap` qua `FileStream` → file gốc không bị khóa |

---

## 🔧 Edge case đã xử lý

| Tình huống | Xử lý |
|-----------|-------|
| File ảnh hỏng | `try/catch` + `MessageBox` lỗi |
| Ghi CSV thất bại (file đang mở) | Bắt `IOException` + báo người dùng |
| Xóa/Cập nhật chưa chọn dòng | `MessageBox` thông tin |
| Mã SP trùng khi thêm | `errorProvider` báo lỗi cạnh `txtProductId` |
| Excel hiển thị sai tiếng Việt | Ghi UTF-8 BOM; hoặc dùng Data → From Text/CSV chọn UTF-8 |

---

## ❓ Câu hỏi vấn đáp thường gặp

**Q: Vai trò của `BindingSource` là gì?**
> Làm trung gian giữa `BindingList<Product>` và `DataGridView`. Cho phép thay đổi datasource khi lọc mà không mất dữ liệu gốc.

**Q: `BindingList<T>` khác `List<T>` ở điểm gì?**
> `BindingList<T>` tự động thông báo cho UI khi có thay đổi (`IBindingList`). `List<T>` không có cơ chế này.

**Q: `Anchor` khác `Dock` ở điểm gì?**
> `Dock` chiếm toàn bộ cạnh/khoảng. `Anchor` giữ khoảng cách cố định với cạnh được neo — phù hợp khi control cần co giãn một phần.

**Q: `ErrorProvider` hoạt động ra sao?**
> Gọi `errorProvider.SetError(control, message)` để hiện icon nhấp nháy bên cạnh control. Gọi `errorProvider.Clear()` để tắt.
