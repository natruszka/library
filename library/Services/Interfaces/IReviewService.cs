using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IReviewService
{
    IList<Review> GetAllReviews();
    Task AddNewReview(ReviewDto reviewDto);
    ICollection<ReviewsView> GetAllReviewsViews();
}