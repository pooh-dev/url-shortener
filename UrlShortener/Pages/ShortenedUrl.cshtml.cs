using AppLibrary.Models;
using AppLibrary.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    }
}
