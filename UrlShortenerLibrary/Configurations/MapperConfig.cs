using AutoMapper;
using UrlShortenerLibrary.Data.Models;

namespace UrlShortenerLibrary.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<UrlData, RequestUrlDto>().ReverseMap();
        CreateMap<UrlData, UrlDto>().ReverseMap();
        CreateMap<UrlUsageData, UrlUsageDto>().ReverseMap();
    }

}
