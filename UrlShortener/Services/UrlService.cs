using AutoMapper;
using UrlShortener.Data;
using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public class UrlService : IUrlService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly int _shiftId; // to make ShortenedUrl longer
    public UrlService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _shiftId = 1000;
    }

    public string AddUrl(RequestDto requestDto)
    {
        var urlData = _mapper.Map<UrlData>(requestDto);
        urlData.CreatedDate = DateTime.UtcNow;

        // this section should be atomic
        // the 'Shortened URL' is based on a unique Id from DB
        // this approach helps us not to check if the 'Shortened URL' already exists in DB
        lock (this)
        {
            var maxId = _dbContext.Urls
                .DefaultIfEmpty()
                .Max(url => url == null ? 0 : url.Id);
            var uniqueInt = _shiftId + maxId;
            urlData.ShortenedUrl = Base62.EncodeUInt64((ulong)uniqueInt);

            _dbContext.Urls.Add(urlData);
            _dbContext.SaveChanges();
        }        

        return urlData.ShortenedUrl;
    }

    public ResponseDto GetUrlByShortenedUrl(string shortenedUrl)
    {
        var urlData = _dbContext.Urls
            .Where(url => url.ShortenedUrl.Equals(shortenedUrl))
            .FirstOrDefault();
        return _mapper.Map<ResponseDto>(urlData);
    }
}
