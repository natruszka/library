namespace library.Entities;

public class Borrow
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTimeOffset BorrowDate { get; set; }
    public DateTimeOffset? ReturnDate { get; set; }
    public DateTimeOffset DueDate { get; set; }
}