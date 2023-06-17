using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Data.Models;

public class RequestDto
{
    [Required]
    [Url]
    [Display(Name = "URL")]
    public string? OriginalUrl { get; set; }
}
