using UrlShortener.Data.Models;

namespace UrlShortener.Repositories;

public interface IUrlRepository
{
    void AddUrl(UrlData urlData);
    UrlData? GetUrlByShortenedUrl(string shortenedUrl);
    int GetMaxId();
}
