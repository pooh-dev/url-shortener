using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Services;

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
                ? RedirectToPage("Error404")
                : Redirect(responseDto.OriginalUrl);
        }
    }
}
