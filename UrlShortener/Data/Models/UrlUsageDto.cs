using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace UrlShortener.Data.Models;

public class UrlUsageDto
{
    [Display(Name = "Accept")]
    public string Accept { get; set; }

    [Display(Name = "Language")]
    public string Language { get; set; }

    [Display(Name = "User Agent")]
    public string UserAgent { get; set; }

    [Display(Name = "IP Address")]
    public string IpAddress { get; set; }
}
