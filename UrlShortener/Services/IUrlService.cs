using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public interface IUrlService
{
    string AddUrl(RequestDto requestDto);
    ResponseDto GetUrlByShortenedUrl(string shortenedUrl);
}
