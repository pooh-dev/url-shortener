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

    public ResponseDto ResponseDto { get; set; }

    public void OnGet(string url)
    {
        ResponseDto = _urlService.GetUrlByShortenedUrl(url);
        ResponseDto.ShortenedUrl = $"{Request.Scheme}://{Request.Host}/{ResponseDto.ShortenedUrl}";
    }
}
