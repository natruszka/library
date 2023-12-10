using System.Data.SqlTypes;

namespace library.Entities;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public bool IsStaff { get; set; }
    public SqlMoney Fine { get; set; }
    public bool IsBanned { get; set; }
}