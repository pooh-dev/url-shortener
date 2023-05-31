using AppLibrary.Models;

namespace AppLibrary.Services;

public interface IUrlService
{
    ResponseDto AddUrl(RequestDto requestDto);
    ResponseDto GetUrlByShortenedUrl(string shortenedUrl);
}
