﻿using library.Entities;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Genres;

public class ShowGenres : PageModel
{
    public List<Genre> Genres { get; set; } = new();
    private readonly IGenreService _genreService;

    public ShowGenres(IGenreService genreService)
    {
        _genreService = genreService;
    }
    public async Task OnGet()
    {
        Genres = new List<Genre>(_genreService.GetAllGenres());
    }

    public RedirectToPageResult OnPost()
    {
        return RedirectToPage("/NewGenre");
    }
    
}