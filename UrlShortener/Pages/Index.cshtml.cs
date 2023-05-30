using AppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UrlShortener.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public RequestDto? Input { get; set; }

    public void OnGet()
    {

    }

    public IActionResult OnPost() 
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("ShortenedUrl");
    }
}