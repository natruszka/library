namespace library.DTOs;

public class ReviewDto
{
    public int MemberId { get; set; }
    public int Rating { get; set; }
    public string? ReviewText { get; set; } 
    public DateTimeOffset ReviewDate { get; set; }
    public string Isbn { get; set; } = null!;
}