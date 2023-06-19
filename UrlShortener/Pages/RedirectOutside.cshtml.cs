using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using UrlShortener.Data.Models;
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
            var url = await _urlService.GetUrlByShortenedUrlAsync(shortenedUrl);

            if (url is null)
            {
                return RedirectToPage("Error404");
            }

            if (url.OwnerName != User.Identity.Name)
            {
                var urlUsageDto = new UrlUsageDto
                {
                    Accept = HttpContext.Request.Headers.Accept.ToString(),
                    Language = HttpContext.Request.Headers.AcceptLanguage.ToString(),
                    UserAgent = HttpContext.Request.Headers.UserAgent.ToString(),
                    IpAddress = HttpContext.Connection.RemoteIpAddress.ToString()
                };

                await _urlService.AddUrlUsageInfoAsync(shortenedUrl, urlUsageDto);
            }

            return Redirect(url.OriginalUrl);
        }
    }
}
