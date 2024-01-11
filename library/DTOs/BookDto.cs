namespace library.DTOs;

public class BookDto
{
    public string Title { get; set; } = null!;
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
    public int PublisherId { get; set; }
    public int Edition { get; set; }
    public string Isbn { get; set; } = null!;
}