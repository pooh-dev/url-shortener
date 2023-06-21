using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public interface IUrlService
{
    Task<string> AddUrlAsync(RequestUrlDto requestDto);
    Task<UrlDto> GetUrlByShortenedUrlAsync(string shortenedUrl, bool includeUsageInfo);
    Task<IEnumerable<UrlDto>> GetUrlsByOwnerNameAsync(string ownerName);
}
