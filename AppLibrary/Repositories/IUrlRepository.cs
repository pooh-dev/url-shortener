using AppLibrary.Models;

namespace AppLibrary.Repositories;

public interface IUrlRepository
{
    UrlData AddUrl(UrlData urlData);
    UrlData? GetUrlByShortenedUrl(string shortenedUrl);
    int GetMaxId();
}
