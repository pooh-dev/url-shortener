namespace UrlShortener.Data.Models;

public class UrlData
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}
