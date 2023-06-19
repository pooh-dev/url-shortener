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
        urlData.UsageInfo = new List<UrlUsageData>();

        await _dbContext.Urls.AddAsync(urlData);
        await _dbContext.SaveChangesAsync();      

        return urlData.ShortenedUrl;
    }

    public async Task AddUrlUsageInfoAsync(string shortenedUrl, UrlUsageDto urlUsageDto)
    {
        var urlData = await GetByShortenedUrlAsync(shortenedUrl);
        var urlUsageData = _mapper.Map<UrlUsageData>(urlUsageDto);
        urlUsageData.UrlDataId = urlData.UrlDataId;
        urlData.UsageInfo ??= new List<UrlUsageData>();
        urlData.UsageInfo.Add(urlUsageData);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UrlDto> GetUrlByShortenedUrlAsync(string shortenedUrl)
    {
        var urlData = await GetByShortenedUrlAsync(shortenedUrl);
        return _mapper.Map<UrlDto>(urlData);
    }

    public async Task<IEnumerable<UrlDto>> GetUrlsByOwnerNameAsync(string ownerName)
    {
        if (String.IsNullOrEmpty(ownerName))
        {
            return Enumerable.Empty<UrlDto>();
        }

        var urlsData = await _dbContext.Urls
            .Where(url => url.OwnerName == ownerName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<UrlDto>>(urlsData);
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

    private async Task<UrlData> GetByShortenedUrlAsync(string shortenedUrl)
    {
        return await _dbContext.Urls
            .Where(url => url.ShortenedUrl == shortenedUrl)
            .Include(url => url.UsageInfo)
            .FirstOrDefaultAsync();
    }
}
