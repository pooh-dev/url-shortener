using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortenerLibrary.Data.Models;
using UrlShortenerLibrary.Services;

namespace UrlShortener.Pages;

[Authorize]
public class UrlUsageInfoModel : PageModel
{
    private readonly IUrlService _urlService;
    public UrlUsageInfoModel(IUrlService urlService)
    {
        _urlService = urlService;
    }

    public UrlDto Url { get; set; }

    public async Task OnGet(string shortenedUrl)
    {
        Url = await _urlService.GetUrlByShortenedUrlAsync(shortenedUrl, includeUsageInfo: true);
        Url.ShortenedUrl = $"{Request.Scheme}://{Request.Host}/{Url.ShortenedUrl}";
    }
}
