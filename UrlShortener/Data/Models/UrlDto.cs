using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Data.Models;

public class UrlDto
{
    [Display(Name = "Distanation URL")]
    public string OriginalUrl { get; set; }

    [Display(Name = "Shortened URL")]
    public string ShortenedUrl { get; set; }

    public string? OwnerName { get; set; }
    public ICollection<UrlUsageDto> UsageInfo { get; set; }
}
