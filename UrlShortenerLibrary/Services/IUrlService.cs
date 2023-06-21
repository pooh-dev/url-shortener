using UrlShortenerLibrary.Data.Models;

namespace UrlShortenerLibrary.Services;

public interface IUrlService
{
    Task<string> AddUrlAsync(RequestUrlDto requestDto);
    Task<UrlDto> GetUrlByShortenedUrlAsync(string shortenedUrl, bool includeUsageInfo);
    Task<IEnumerable<UrlDto>> GetUrlsByOwnerNameAsync(string ownerName);
}
