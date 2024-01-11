namespace library.Entities;

public class Book
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; } = null!;
    public int GenreId { get; set; }
    public int PublisherId { get; set; }
    public int Edition { get; set; }
    public bool IsBorrowed { get; set; }
    public bool IsOrdered { get; set; }
    public string Isbn { get; set; } = null!;
}