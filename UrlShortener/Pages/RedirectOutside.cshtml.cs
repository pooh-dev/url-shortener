using AppLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UrlShortener.Pages
{
    public class RedirectOutsideModel : PageModel
    {
        private readonly IUrlService _urlService;
        public RedirectOutsideModel(IUrlService urlService)
        {
            _urlService = urlService;
        }

        public IActionResult OnGet(string shortenedUrl)
        {
            var responseDto = _urlService.GetUrlByShortenedUrl(shortenedUrl);

            return responseDto is null
                ? RedirectToPage("Index")
                : Redirect(responseDto.OriginalUrl);
        }
    }
}
