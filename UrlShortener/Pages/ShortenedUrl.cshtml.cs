using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortenerLibrary.Data.Models;
using UrlShortenerLibrary.Services;

namespace UrlShortener.Pages;

public class ShortenedUrlModel : PageModel
{
    private readonly IUrlService _urlService;
    public ShortenedUrlModel(IUrlService urlService)
    {
        _urlService = urlService;
    }

    public UrlDto ResponseDto { get; set; }

    public async Task OnGet(string url)
    {
        ResponseDto = await _urlService.GetUrlByShortenedUrlAsync(shortenedUrl: url, includeUsageInfo: false);
        ResponseDto.ShortenedUrl = $"{Request.Scheme}://{Request.Host}/{ResponseDto.ShortenedUrl}";
    }
}
