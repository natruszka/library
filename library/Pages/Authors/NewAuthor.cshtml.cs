using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace library.Pages.Authors;
[IgnoreAntiforgeryToken(Order = 1001)]
[Authorize(Policy = "IsStaff")]
public class NewAuthor : PageModel
{
    [BindProperty] public AuthorDto NewAuthorDto { get; set; } = new();
    private readonly IAuthorService _authorService;

    public NewAuthor(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    public async Task OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        try
        {
            await _authorService.AddNewAuthor(NewAuthorDto);
            return RedirectToPage("/Authors/ShowAuthors");
        }
        catch (NpgsqlException ex)
        {
            return Page();
        }
    }
}