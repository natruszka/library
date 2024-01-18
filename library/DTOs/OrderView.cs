namespace library.DTOs;

public class OrderView
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}