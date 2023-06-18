using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Data.Models;
using UrlShortener.Services;

namespace UrlShortener.Pages;

public class ShortenedUrlModel : PageModel
{
    private readonly IUrlService _urlService;
    public ShortenedUrlModel(IUrlService urlService)
    {
        _urlService = urlService;
    }

    public ResponseUrlDto ResponseDto { get; set; }

    public async Task OnGet(string url)
    {
        ResponseDto = await _urlService.GetUrlByShortenedUrlAsync(url);
        ResponseDto.ShortenedUrl = $"{Request.Scheme}://{Request.Host}/{ResponseDto.ShortenedUrl}";
    }
}
