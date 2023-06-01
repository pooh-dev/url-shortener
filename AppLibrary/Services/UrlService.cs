
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

    public string AddUrl(RequestDto requestDto)
    {
        var urlData = _mapper.Map<UrlData>(requestDto);
        urlData.CreatedDate = DateTime.UtcNow;

        // this section should be atomic
        // the 'Shortened URL' is based on a unique Id from DB
        // this approach helps us not to check if the 'Shortened URL' already exists in DB
        lock (this)
        {
            var uniqueInt = _shiftId + _urlRepository.GetMaxId();
            urlData.ShortenedUrl = Base62.EncodeUInt64((ulong)uniqueInt);
            _urlRepository.AddUrl(urlData);
        }        

        return urlData.ShortenedUrl;
    }

    public ResponseDto GetUrlByShortenedUrl(string shortenedUrl)
    {
        var urlData = _urlRepository.GetUrlByShortenedUrl(shortenedUrl);
        return _mapper.Map<ResponseDto>(urlData);
    }
}
