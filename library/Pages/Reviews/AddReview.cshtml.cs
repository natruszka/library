using System.Security.Claims;
using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Reviews;
[Authorize]
[IgnoreAntiforgeryToken(Order = 1001)]
public class AddReview : PageModel
{
    private readonly IReviewService _reviewService;
    [TempData]
    public int UserId { get; set; }
    [BindProperty] public ReviewDto NewReview { get; set; } = new();
    
    public AddReview(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    public void OnGet(string isbn)
    {
        var userId = User.Claims.First(c => c.Type == ClaimTypes.Sid).Value;
        UserId = Convert.ToInt32(userId);
        NewReview.Isbn = isbn;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/Books/ShowBooks");
            }

            NewReview.MemberId = UserId;
            await _reviewService.AddNewReview(NewReview);
            return RedirectToPage("/Reviews/ShowReviews");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToPage("/Books/ShowBooks");
        }
    }
}