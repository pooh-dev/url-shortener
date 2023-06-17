using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public interface IUrlService
{
    Task<string> AddUrlAsync(RequestDto requestDto);
    Task<ResponseDto> GetUrlByShortenedUrlAsync(string shortenedUrl);
    Task<bool> UrlExistAsync(string shortenedUrl);
}
