using AutoMapper;
using System.Threading.Channels;
using UrlShortener.Data;
using UrlShortener.Data.Models;

namespace UrlShortener.Services;

public class UrlUsageInfoHandler
{
    private static Channel<UrlUsageDto> urlUsageInfoChannel = Channel.CreateUnbounded<UrlUsageDto>();

    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    public UrlUsageInfoHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async ValueTask AddForHandling(UrlUsageDto urlUsageInfo)
    {
        await urlUsageInfoChannel.Writer.WriteAsync(urlUsageInfo);
    }

    public async ValueTask Handle()
    {
        if (urlUsageInfoChannel.Reader.Count > 0)
        {
            var urlUsageDtos = new List<UrlUsageDto>();
            while (urlUsageInfoChannel.Reader.TryRead(out UrlUsageDto urlUsageDto))
            {
                urlUsageDtos.Add(urlUsageDto);
            }
            var urlUsageDatas = _mapper.Map<List<UrlUsageData>>(urlUsageDtos);
            
            await _dbContext.UrlUsageDatas.AddRangeAsync(urlUsageDatas);
            await _dbContext.SaveChangesAsync();
        }
    }
}
