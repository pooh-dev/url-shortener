using AppLibrary.Models;

namespace AppLibrary.Repositories;

public class UrlRepository : IUrlRepository
{
    private readonly AppDbContext _context;
    public UrlRepository(AppDbContext context)
    {
        _context = context;
    }

    public UrlData AddUrl(UrlData urlData)
    {
        _context.Urls.Add(urlData);
        _context.SaveChanges();
        return urlData;
    }

    public UrlData? GetUrlByShortenedUrl(string shortenedUrl)
    {
        return _context.Urls
            .Where(url => url.ShortenedUrl.Equals(shortenedUrl))
            .SingleOrDefault();
    }

    public int GetMaxId()
    {
        return _context.Urls.Max(url => url.Id);
    }
}
