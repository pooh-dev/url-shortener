using System.ComponentModel.DataAnnotations;
namespace UrlShortenerLibrary.Data.Models;

public class UrlUsageDto
{
    public int UrlDataId { get; set; }

    [Display(Name = "Accept")]
    public string Accept { get; set; }

    [Display(Name = "Language")]
    public string Language { get; set; }

    [Display(Name = "User Agent")]
    public string UserAgent { get; set; }

    [Display(Name = "IP Address")]
    public string IpAddress { get; set; }
}
