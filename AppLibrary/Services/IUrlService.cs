using AppLibrary.Models;

namespace AppLibrary.Services;

public interface IUrlService
{
    string AddUrl(RequestDto requestDto);
    ResponseDto GetUrlByShortenedUrl(string shortenedUrl);
}
