using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Reviews;
[Authorize]
public class ShowReviews : PageModel
{
    public List<ReviewsView> Reviews { get; set; } = new();
    private readonly IReviewService _reviewService;
    [ActivatorUtilitiesConstructor]
    public ShowReviews(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    public async Task OnGet()
    {
        Reviews = new List<ReviewsView>(_reviewService.GetAllReviewsViews());
    }
}