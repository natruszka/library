namespace library.DTOs;

public class BorrowDto
{
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTimeOffset BorrowDate { get; set; }
}