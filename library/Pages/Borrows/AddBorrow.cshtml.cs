using System.Security.Claims;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Borrows;
[Authorize]
public class AddBorrow : PageModel
{
    private readonly IBorrowService _borrowService;

    public AddBorrow(IBorrowService borrowService)
    {
        _borrowService = borrowService;
    }
    public async Task<IActionResult> OnGet(string isbn)
    {
        try
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.Sid).Value;
            await _borrowService.AddNewBorrow(Convert.ToInt32(userId), isbn);
            return RedirectToPage("/Borrows/ShowBorrows");
        }
        catch
        {
            return RedirectToPage("/Books/ShowBooks");
        }
    }
}