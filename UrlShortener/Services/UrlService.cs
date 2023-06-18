using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task<string> AddUrlAsync(RequestUrlDto requestDto)
    {
        var urlData = _mapper.Map<UrlData>(requestDto);
        urlData.ShortenedUrl = await GetShortenedUrlAsync();

        await _dbContext.Urls.AddAsync(urlData);
        await _dbContext.SaveChangesAsync();      

        return urlData.ShortenedUrl;
    }

    public async Task<ResponseUrlDto> GetUrlByShortenedUrlAsync(string shortenedUrl)
    {
        var urlData = await _dbContext.Urls
            .Where(url => url.ShortenedUrl == shortenedUrl)
            .FirstOrDefaultAsync();

        return _mapper.Map<ResponseUrlDto>(urlData);
    }

    public async Task<IEnumerable<ResponseUrlDto>> GetUrlsByOwnerNameAsync(string ownerName)
    {
        if (String.IsNullOrEmpty(ownerName))
        {
            return Enumerable.Empty<ResponseUrlDto>();
        }

        var urlsData = await _dbContext.Urls
            .Where(url => url.OwnerName == ownerName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ResponseUrlDto>>(urlsData);
    }

    public async Task<bool> UrlExistAsync(string shortenedUrl)
    {
        return await _dbContext.Urls
            .Where(url => url.ShortenedUrl == shortenedUrl)
            .AnyAsync();
    }

    protected async Task<string> GetShortenedUrlAsync()
    {
        string shortenedUrl;
        do
        {
            shortenedUrl = Guid.NewGuid().ToString()[..8];
        } while (await UrlExistAsync(shortenedUrl));

        return shortenedUrl;
    }
}
