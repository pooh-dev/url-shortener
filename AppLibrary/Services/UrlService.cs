
using AppLibrary.Models;
using AppLibrary.Repositories;
using AutoMapper;

namespace AppLibrary.Services;

public class UrlService : IUrlService
{
    private readonly IUrlRepository _urlRepository;
    private readonly IMapper _mapper;
    private readonly int _shiftId; // to make ShortenedUrl longer
    public UrlService(IUrlRepository urlRepository, IMapper mapper)
    {
        _urlRepository = urlRepository;
        _mapper = mapper;
        _shiftId = 1000;
    }

    public ResponseDto AddUrl(RequestDto requestDto)
    {
        var urlData = _mapper.Map<UrlData>(requestDto);
        var uniqueInt = _shiftId + _urlRepository.GetMaxId();
        urlData.ShortenedUrl = Base62.EncodeUInt64((ulong)uniqueInt);
        urlData.CreatedDate = DateTime.UtcNow;
        _urlRepository.AddUrl(urlData);

        return _mapper.Map<ResponseDto>(urlData);
    }

    public ResponseDto GetUrlByShortenedUrl(string shortenedUrl)
    {
        var urlData = _urlRepository.GetUrlByShortenedUrl(shortenedUrl);
        return _mapper.Map<ResponseDto>(urlData);
    }
}
