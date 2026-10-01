using System.ComponentModel;

namespace TechMartManager.Models;

/// <summary>Model sản phẩm công nghệ dùng cho BindingList binding.</summary>
public class Product
{
    public string ProductId   { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string Category    { get; set; } = string.Empty;

    [DisplayName("Đơn Giá (VNĐ)")]
    public decimal UnitPrice  { get; set; }

    public int Quantity       { get; set; }

    /// <summary>Đường dẫn ảnh đại diện (không lưu vào CSV).</summary>
    [Browsable(false)]
    public string? ImagePath  { get; set; }
}
