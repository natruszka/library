using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Books;

public class ShowBooks : PageModel
{
    private readonly IBookService _bookService;
    public List<BookView> BookViews { get; set; }  = new();
    public ShowBooks(IBookService bookService)
    {
        _bookService = bookService;
    }
    public async Task OnGet()
    {
        BookViews = new List<BookView>(_bookService.GetAllBooks());
    }

    public RedirectToPageResult OnPost()
    {
        return RedirectToPage("/NewBook");
    }
}