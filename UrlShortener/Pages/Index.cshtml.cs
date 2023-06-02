﻿using AppLibrary.Models;
using AppLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UrlShortener.Pages;

public class IndexModel : PageModel
{
    private readonly IUrlService _urlService;
    public IndexModel(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [BindProperty]
    public RequestDto RequestDto { get; set; }

    public void OnGet() { }

    public IActionResult OnPost() 
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var shortenedUrl = _urlService.AddUrl(RequestDto);

        return RedirectToPage("ShortenedUrl", new { url = shortenedUrl});
    }
}