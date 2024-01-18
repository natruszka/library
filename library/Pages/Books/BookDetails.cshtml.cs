using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Books;
[Authorize]
public class BookDetails : PageModel
{
    private readonly IBookService _bookService;
    public List<BookMoreInfo> BookMoreInfos { get; set; } = new();

    public BookDetails(IBookService bookService)
    {
        _bookService = bookService;
    }
    public void OnGet(string isbn)
    {
        BookMoreInfos = new List<BookMoreInfo>(_bookService.GetBookByIsbn(isbn));
    }
}