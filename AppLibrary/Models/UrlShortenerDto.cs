using System.ComponentModel.DataAnnotations;

namespace AppLibrary.Models;

public class UrlShortenerDto
{
    [Required]
    [Url]
    [Display(Name = "URL")]
    public string? OriginalUrl { get; set; }

    [Url]
    public string? ShortenedUrl { get; set; }

    public uint RequestCounter { get; set; }
}
