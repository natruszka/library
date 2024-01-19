using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IReviewService
{
    Task AddNewReview(ReviewDto reviewDto);
    ICollection<ReviewsView> GetAllReviewsViews();
}