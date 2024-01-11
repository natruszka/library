using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Genres;

[IgnoreAntiforgeryToken(Order = 1001)]
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

    public RedirectToPageResult OnPost()
    {
        _genreService.AddNewGenre(NewGenreDto);
        return RedirectToPage("Genres/ShowGenres");
    }
    
}