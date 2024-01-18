using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Borrows;
[Authorize]
public class ShowBorrows : PageModel
{
    public List<BorrowView> BorrowViews { get; set; } = new();
    private readonly IBorrowService _borrowService;

    public ShowBorrows(IBorrowService borrowService)
    {
        _borrowService = borrowService;
    }
    public async Task OnGet()
    {
        BorrowViews = new List<BorrowView>(_borrowService.GetBorrowViews());
    }
}