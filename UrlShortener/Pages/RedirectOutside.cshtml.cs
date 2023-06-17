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

        public async Task<IActionResult> OnGet(string shortenedUrl)
        {
            var responseDto = await _urlService.GetUrlByShortenedUrlAsync(shortenedUrl);

            return responseDto is null
                ? RedirectToPage("Error404")
                : Redirect(responseDto.OriginalUrl);
        }
    }
}
