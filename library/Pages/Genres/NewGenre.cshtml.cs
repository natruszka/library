using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Genres;

[IgnoreAntiforgeryToken(Order = 1001)]
[Authorize(Policy = "IsStaff")]
public class NewGenre : PageModel
{
    [BindProperty] public GenreDto NewGenreDto { get; set; } = new();
    private readonly IGenreService _genreService;

    public NewGenre(IGenreService genreService)
    {
        _genreService = genreService;
    }
    public async Task OnGetAsync(int GenreId)
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        try
        {
            await _genreService.AddNewGenre(NewGenreDto);
            return RedirectToPage("/Genres/ShowGenres");
        }
        catch
        {
            return RedirectToPage("/Genres/ShowGenres");
        }
    }
    
}