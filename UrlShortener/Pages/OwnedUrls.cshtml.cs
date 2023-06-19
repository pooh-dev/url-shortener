using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Data.Models;
using UrlShortener.Services;

namespace UrlShortener.Pages;

[Authorize]
public class OwnedUrlsModel : PageModel
{
    private readonly IUrlService _urlService;
    public OwnedUrlsModel(IUrlService urlService)
    {
        _urlService = urlService;
    }

    public IEnumerable<UrlDto> Urls { get; set; }

    public async Task OnGetAsync()
    {
        Urls = await _urlService.GetUrlsByOwnerNameAsync(User.Identity.Name);
    }
}
