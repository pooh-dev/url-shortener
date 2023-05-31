using AppLibrary.Models;
using AutoMapper;

namespace AppLibrary.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<UrlData, RequestDto>().ReverseMap();
        CreateMap<UrlData, ResponseDto>().ReverseMap();
    }

}
