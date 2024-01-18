namespace library.DTOs;

public class BookMoreInfo
{
    public string Title { get; set; } = null!;
    public AuthorDto Author { get; set; } = null!;
    public string GenreName { get; set; } = null!;
    public string PublisherName { get; set; } = null!;
    public int Edition { get; set; }
    public string Isbn { get; set; } = null!;
    public int? Rating { get; set; }
    public string? ReviewText { get; set; }
    public string? Username { get; set; }
}