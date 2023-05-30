using System.ComponentModel.DataAnnotations;

namespace AppLibrary.Models;

public class RequestDto
{
    [Required]
    [Url]
    [Display(Name = "URL")]
    public string? OriginalUrl { get; set; }
}
