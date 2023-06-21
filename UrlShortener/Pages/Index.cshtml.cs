using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortenerLibrary.Data.Models;
using UrlShortenerLibrary.Services;

namespace UrlShortener.Pages;

public class IndexModel : PageModel
{
    private readonly IUrlService _urlService;
    public IndexModel(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [BindProperty]
    public RequestUrlDto RequestDto { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPost() 
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (User.Identity.IsAuthenticated)
        {
            RequestDto.OwnerName = User.Identity.Name;
        }

        var shortenedUrl = await _urlService.AddUrlAsync(RequestDto);

        return RedirectToPage("ShortenedUrl", new { url = shortenedUrl});
    }
}