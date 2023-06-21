using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Data.Models;
using UrlShortener.Services;

namespace UrlShortener.Pages
{
    public class RedirectOutsideModel : PageModel
    {
        private readonly IUrlService _urlService;
        private readonly UrlUsageInfoHandler _urlUsageInfoHandler;
        public RedirectOutsideModel(IUrlService urlService, UrlUsageInfoHandler urlUsageInfoHandler)
        {
            _urlService = urlService;
            _urlUsageInfoHandler = urlUsageInfoHandler;
        }

        public async Task<IActionResult> OnGet(string shortenedUrl)
        {
            var url = await _urlService.GetUrlByShortenedUrlAsync(shortenedUrl, includeUsageInfo: false);

            if (url is null)
            {
                return RedirectToPage("Error404");
            }

            if (url.OwnerName != User.Identity.Name)
            {
                var urlUsageDto = new UrlUsageDto
                {
                    UrlDataId = url.UrlDataId,
                    Accept = HttpContext.Request.Headers.Accept.ToString(),
                    Language = HttpContext.Request.Headers.AcceptLanguage.ToString(),
                    UserAgent = HttpContext.Request.Headers.UserAgent.ToString(),
                    IpAddress = HttpContext.Connection.RemoteIpAddress.ToString()
                }; 
                await _urlUsageInfoHandler.AddForHandling(urlUsageDto);
            }

            return Redirect(url.OriginalUrl);
        }
    }
}
