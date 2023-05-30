namespace AppLibrary.Models;

public class UrlData
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }
    public uint? RequestCounter { get; set; }
}
