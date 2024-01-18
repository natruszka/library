namespace library.DTOs;

public class BorrowView
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTimeOffset BorrowDate { get; set; }
    public DateTimeOffset? ReturnDate { get; set; }
    public DateTimeOffset DueDate { get; set; }
}