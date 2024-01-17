using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace library.Pages.Books;
[IgnoreAntiforgeryToken(Order = 1001)]

public class NewBook : PageModel
{
    [BindProperty] public BookDto NewBookDto { get; set; } = new();
    private readonly IBookService _bookService;

    public NewBook(IBookService bookService)
    {
        _bookService = bookService;
    }
    public async Task OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        try
        {
            await _bookService.AddNewBook(NewBookDto);
            return RedirectToPage("/Books/ShowBooks");
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
            return Page();
        }
    }
}