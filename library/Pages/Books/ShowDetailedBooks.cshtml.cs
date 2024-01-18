using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Books;
[Authorize(Policy = "IsStaff")]
public class ShowDetailedBooks : PageModel
{
    public List<BookDetailedView> BookDetailedViews { get; set; } = new();
    private readonly IBookService _bookService;

    public ShowDetailedBooks(IBookService bookService)
    {
        _bookService = bookService;
    }
    public void OnGet()
    {
        BookDetailedViews = new List<BookDetailedView>(_bookService.GetDetailsAllBooks());
    }
}