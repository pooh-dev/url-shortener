using AutoMapper;
using UrlShortener.Data.Models;

namespace UrlShortener.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<UrlData, RequestUrlDto>().ReverseMap();
        CreateMap<UrlData, UrlDto>().ReverseMap();
        CreateMap<UrlUsageData, UrlUsageDto>().ReverseMap();
    }

}
