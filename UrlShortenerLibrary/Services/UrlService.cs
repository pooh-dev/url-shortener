using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrlShortenerLibrary.Data;
using UrlShortenerLibrary.Data.Models;

namespace UrlShortenerLibrary.Services;

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

        await _dbContext.UrlDatas.AddAsync(urlData);
        await _dbContext.SaveChangesAsync();      

        return urlData.ShortenedUrl;
    }

    public async Task<UrlDto> GetUrlByShortenedUrlAsync(string shortenedUrl, bool includeUsageInfo)
    {
        var urlDataQuery = _dbContext.UrlDatas
            .Where(url => url.ShortenedUrl == shortenedUrl);

        if (includeUsageInfo)
        {
            urlDataQuery = urlDataQuery.Include(url => url.UsageInfo);
        }

        var urlData = await urlDataQuery.FirstOrDefaultAsync();

        return _mapper.Map<UrlDto>(urlData);
    }

    public async Task<IEnumerable<UrlDto>> GetUrlsByOwnerNameAsync(string ownerName)
    {
        if (String.IsNullOrEmpty(ownerName))
        {
            return Enumerable.Empty<UrlDto>();
        }

        var urlsData = await _dbContext.UrlDatas
            .Where(url => url.OwnerName == ownerName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<UrlDto>>(urlsData);
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

    protected async Task<bool> UrlExistAsync(string shortenedUrl)
    {
        return await _dbContext.UrlDatas
            .Where(url => url.ShortenedUrl == shortenedUrl)
            .AnyAsync();
    }
}
