namespace TechMartManager.Models;

/// <summary>Danh mục sản phẩm dùng cho ComboBox binding.</summary>
public class CategoryItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public override string ToString() => Name;
}
