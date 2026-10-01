# Checklist kiểm thử thủ công — TechMart Product Manager

> **Hướng dẫn:** Mở ứng dụng, thực hiện từng bước, ghi kết quả vào cột "Kết quả thực tế".

---

## TC01 — Responsive Layout

| Bước | Thao tác | Kết quả kỳ vọng | Kết quả thực tế | Trạng thái |
|------|----------|-----------------|-----------------|-----------|
| 1 | Mở ứng dụng | Form hiện ra cân đối | | |
| 2 | Nhấn nút Maximize (phóng to) | TableLayoutPanel chia 35%/65%; DataGridView phình to lấp đầy cột phải; các TextBox co giãn thẳng hàng | | |
| 3 | Kéo co cửa sổ nhỏ lại | Giao diện không bị vỡ (MinimumSize chặn) | | |

---

## TC02 — Validation ErrorProvider

| Bước | Thao tác | Kết quả kỳ vọng | Kết quả thực tế | Trạng thái |
|------|----------|-----------------|-----------------|-----------|
| 1 | Để trống ô "Tên SP" | | | |
| 2 | Nhập Đơn giá = `-50000` | | | |
| 3 | Bấm "Thêm mới" | Icon ErrorProvider nhấp nháy đỏ cạnh 2 ô. Không thêm vào danh sách | | |
| 4 | Sửa lại đúng → bấm "Thêm mới" | Icon lỗi biến mất. Thêm thành công | | |

---

## TC03 — Data Binding & Format Đơn Giá

| Bước | Thao tác | Kết quả kỳ vọng | Kết quả thực tế | Trạng thái |
|------|----------|-----------------|-----------------|-----------|
| 1 | Nhập Tên SP = "Laptop Dell", Đơn giá = `25000000`, SL = `1`, chọn Laptop | | | |
| 2 | Bấm "Thêm mới" | DataGridView hiện dòng mới. Cột Đơn Giá hiển thị `25,000,000` | | |

---

## TC04 — Nạp Ảnh OpenFileDialog

| Bước | Thao tác | Kết quả kỳ vọng | Kết quả thực tế | Trạng thái |
|------|----------|-----------------|-----------------|-----------|
| 1 | Bấm "Chọn Ảnh" | Hộp thoại OpenFileDialog mở, lọc file ảnh (.png, .jpg, ...) | | |
| 2 | Chọn 1 file .png | Ảnh hiển thị trong PictureBox, SizeMode = Zoom, không bị méo | | |
| 3 | Bấm "Thêm mới" để lưu | Sản phẩm được thêm với ảnh đính kèm | | |

---

## TC05 — Xóa Sản Phẩm

| Bước | Thao tác | Kết quả kỳ vọng | Kết quả thực tế | Trạng thái |
|------|----------|-----------------|-----------------|-----------|
| 1 | Click chọn 1 dòng trên DataGridView | Dữ liệu nạp lên form bên trái | | |
| 2 | Bấm nút "Xóa" | MessageBox hiện Yes/No với icon ❓ Question | | |
| 3 | Chọn **Yes** | Dòng biến mất. StatusStrip cập nhật số lượng | | |
| 4 | Chọn **No** | Dòng giữ nguyên | | |

---

## Các test thêm

| Kịch bản | Kết quả kỳ vọng | Kết quả thực tế |
|----------|-----------------|-----------------|
| Bấm "Xóa" khi chưa chọn dòng nào | MessageBox thông báo "Chưa chọn dòng" | |
| Tìm kiếm "lap" → kết quả lọc real-time | Chỉ hiện sản phẩm có tên chứa "lap" | |
| Tìm kiếm xóa hết → danh sách đầy đủ trở lại | Toàn bộ sản phẩm hiện lại | |
| Xuất CSV → mở bằng Excel | Tiếng Việt đúng, định dạng số có dấu phẩy | |
| Ctrl+E | Mở dialog xuất CSV | |
| Ctrl+X | Thoát ứng dụng | |
