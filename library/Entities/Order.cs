using library.Enums;

namespace library.Entities;

public class Order
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public OrderStatus Status { get; set; }
}