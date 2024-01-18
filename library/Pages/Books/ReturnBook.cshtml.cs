using System.Security.Claims;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Books;
[Authorize]
public class ReturnBook : PageModel
{
    private readonly IBorrowService _borrowService;

    public ReturnBook(IBorrowService borrowService)
    {
        _borrowService = borrowService;
    }
    public async Task<IActionResult> OnGet(int bookId)
    {
        try
        {
            await _borrowService.ReturnBook(bookId);
            return RedirectToPage(
                "/Index");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToPage("/Index");
        }
    }
}