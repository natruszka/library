namespace library.Entities;

public class Review
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int Rating { get; set; }
    public string? ReviewText { get; set; }
    public DateTimeOffset? ReviewDate { get; set; }
    public string BookIsbn { get; set; } = null!;
}
