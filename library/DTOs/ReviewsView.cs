namespace library.DTOs;

public class ReviewsView
{
    public int ReviewId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Rating { get; set; }
    public string? Text { get; set; }
    public DateTimeOffset Date { get; set; }
}