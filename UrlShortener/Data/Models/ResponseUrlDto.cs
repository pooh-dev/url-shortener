using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Data.Models;

public class ResponseUrlDto
{
    [Display(Name = "Original")]
    public string OriginalUrl { get; set; }

    [Display(Name = "Shortened")]
    public string ShortenedUrl { get; set; }
}
