using library.DTOs;
using library.Entities;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Authors;
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

    public RedirectToPageResult OnPost()
    {
        return RedirectToPage("/NewAuthor");
    }
}