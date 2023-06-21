namespace UrlShortenerLibrary.Data.Models;

public class UrlUsageData
{
    public int UrlUsageDataId { get; set; }
    public int UrlDataId { get; set; }
    public string Accept { get; set; }
    public string Language { get; set; }
    public string UserAgent { get; set; }
    public string IpAddress { get; set; }
}
