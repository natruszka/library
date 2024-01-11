namespace library.DTOs;

public class BookView
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public AuthorDto Author { get; set; } = null!;
    public string GenreName { get; set; } = null!;
    public string PublisherName { get; set; } = null!;
    public int Edition { get; set; }
    public bool IsBorrowed { get; set; }
    public bool IsOrdered { get; set; }
    public decimal AverageRating { get; set; }
    public int RatingsCount { get; set; }
}