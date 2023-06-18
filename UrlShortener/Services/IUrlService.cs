using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public interface IUrlService
{
    Task<string> AddUrlAsync(RequestUrlDto requestDto);
    Task<ResponseUrlDto> GetUrlByShortenedUrlAsync(string shortenedUrl);
    Task<IEnumerable<ResponseUrlDto>> GetUrlsByOwnerNameAsync(string ownerName);
    Task<bool> UrlExistAsync(string shortenedUrl);
}
