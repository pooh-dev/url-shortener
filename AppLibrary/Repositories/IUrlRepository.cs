using AppLibrary.Models;

namespace AppLibrary.Repositories;

public interface IUrlRepository
{
    void AddUrl(UrlData urlData);
    UrlData? GetUrlByShortenedUrl(string shortenedUrl);
    int GetMaxId();
}
