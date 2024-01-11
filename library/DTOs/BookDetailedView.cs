namespace library.DTOs;

public class BookDetailedView
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public AuthorDto Author { get; set; } = null!;
    public string GenreName { get; set; } = null!;
    public string PublisherName { get; set; } = null!;
    public int Edition { get; set; }
    public bool IsBorrowed { get; set; }
    public bool IsOrdered { get; set; }
    public string Isbn { get; set; } = null!;
}