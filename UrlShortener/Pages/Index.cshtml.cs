using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Data.Models;
using UrlShortener.Services;

namespace UrlShortener.Pages;

public class IndexModel : PageModel
{
    private readonly IUrlService _urlService;
    public IndexModel(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [BindProperty]
    public RequestDto RequestDto { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPost() 
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var shortenedUrl = await _urlService.AddUrlAsync(RequestDto);

        return RedirectToPage("ShortenedUrl", new { url = shortenedUrl});
    }
}