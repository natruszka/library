using library.DTOs;
using library.Entities;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Authors;
[Authorize]
public class ShowAuthors : PageModel
{
    public List<Author> Authors { get; set; } = new();
    private readonly IAuthorService _authorService;

    public ShowAuthors(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    public async Task OnGet()
    {
        Authors = new List<Author>(_authorService.GetAllAuthors());
    }
    
}