namespace library.DTOs;

public class UserOrderView
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string UserSurname { get; set; } = null!;
    public bool IsStaff { get; set; }
    public bool IsBanned { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}