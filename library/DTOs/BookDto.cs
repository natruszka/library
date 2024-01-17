namespace library.DTOs;

public class BookDto
{
    public string Title { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
    public string AuthorSurName { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Publisher { get; set; } = null!;
    public int Edition { get; set; }
    public string Isbn { get; set; } = null!;
}