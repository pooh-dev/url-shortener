using AutoMapper;
using UrlShortener.Data;
using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public class UrlService : IUrlService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    public UrlService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public string AddUrl(RequestDto requestDto)
    {
        var urlData = _mapper.Map<UrlData>(requestDto);
        urlData.ShortenedUrl = GetShortenedUrl();

        _dbContext.Urls.Add(urlData);
        _dbContext.SaveChanges();      

        return urlData.ShortenedUrl;
    }

    public ResponseDto GetUrlByShortenedUrl(string shortenedUrl)
    {
        var urlData = _dbContext.Urls
            .Where(url => url.ShortenedUrl.Equals(shortenedUrl))
            .FirstOrDefault();
        return _mapper.Map<ResponseDto>(urlData);
    }

    public bool UrlExist(string shortenedUrl)
    {
        return _dbContext.Urls
            .Where(url => url.ShortenedUrl == shortenedUrl)
            .Any();
    }

    protected string GetShortenedUrl()
    {
        string shortenedUrl;
        do
        {
            shortenedUrl = Guid.NewGuid().ToString()[..8];
        } while (UrlExist(shortenedUrl));

        return shortenedUrl;
    }
}
