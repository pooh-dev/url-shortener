using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public interface IUrlService
{
    Task<string> AddUrlAsync(RequestUrlDto requestDto);
    Task AddUrlUsageInfoAsync(string shortenedUrl, UrlUsageDto urlUsageDto);
    Task<UrlDto> GetUrlByShortenedUrlAsync(string shortenedUrl);
    Task<IEnumerable<UrlDto>> GetUrlsByOwnerNameAsync(string ownerName);
    Task<bool> UrlExistAsync(string shortenedUrl);
}
