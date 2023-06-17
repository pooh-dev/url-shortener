using AutoMapper;
using UrlShortener.Data.Models;

namespace UrlShortener.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<UrlData, RequestDto>().ReverseMap();
        CreateMap<UrlData, ResponseDto>().ReverseMap();
    }

}
