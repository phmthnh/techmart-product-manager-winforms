using System.Globalization;
using System.Text;
using TechMartManager.Models;

namespace TechMartManager.Helpers;

/// <summary>
/// Các hàm tiện ích độc lập với giao diện.
/// Tách ra để có thể unit test trên mọi OS.
/// </summary>
public static class AppHelpers
{
    private static int _autoIdCounter = 1;

    /// <summary>Sinh mã sản phẩm tự động: SP001, SP002, ...</summary>
    public static string GenerateProductId() =>
        $"SP{_autoIdCounter++:D3}";

    /// <summary>Reset bộ đếm (dùng khi test).</summary>
    public static void ResetIdCounter(int start = 1) => _autoIdCounter = start;

    /// <summary>
    /// Phân tích chuỗi giá — chấp nhận "25000000", "25,000,000", "25.000.000".
    /// Trả về null nếu không hợp lệ.
    /// </summary>
    public static decimal? ParsePrice(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;
        // Xóa dấu chấm và dấu phẩy, thử parse
        string cleaned = input.Replace(".", "").Replace(",", "").Trim();
        return decimal.TryParse(cleaned, out decimal result) ? result : null;
    }

    /// <summary>Chuẩn hóa chuỗi tìm kiếm: lowercase, không phân biệt dấu.</summary>
    public static bool MatchesSearch(string source, string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return true;
        return source.Contains(keyword, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Tạo nội dung CSV từ danh sách sản phẩm.
    /// - Ghi UTF-8 có BOM để Excel đọc đúng tiếng Việt.
    /// - Escape dấu phẩy, ngoặc kép, xuống dòng trong ô.
    /// - Chống CSV injection: ô bắt đầu bằng =, +, -, @ thêm tiền tố '.
    /// </summary>
    public static string BuildCsvContent(IEnumerable<Product> products)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Mã SP,Tên SP,Danh Mục,Đơn Giá (VNĐ),Số Lượng");

        foreach (var p in products)
        {
            sb.AppendLine(string.Join(",",
                CsvCell(p.ProductId),
                CsvCell(p.ProductName),
                CsvCell(p.Category),
                p.UnitPrice.ToString("N0", CultureInfo.InvariantCulture),
                p.Quantity.ToString()
            ));
        }
        return sb.ToString();
    }

    /// <summary>Escape một ô CSV: bao bằng ngoặc kép nếu cần, chống injection.</summary>
    private static string CsvCell(string value)
    {
        // Chống CSV injection
        if (!string.IsNullOrEmpty(value) && "=+-@".Contains(value[0]))
            value = "'" + value;

        // Escape nếu chứa dấu phẩy, ngoặc kép hoặc xuống dòng
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
            value = $"\"{value.Replace("\"", "\"\"")}\"";

        return value;
    }
}
