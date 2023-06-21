namespace UrlShortenerLibrary.Data.Models;

public class UrlData
{
    public int UrlDataId { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }
    public string? OwnerName { get; set; }
    public ICollection<UrlUsageData>? UsageInfo { get; set; }
}
