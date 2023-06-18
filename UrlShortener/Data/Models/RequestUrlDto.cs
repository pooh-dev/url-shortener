using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Data.Models;

public class RequestUrlDto
{
    [Required]
    [Url]
    [Display(Name = "URL")]
    public string? OriginalUrl { get; set; }

    public string? OwnerName { get; set; }
}
