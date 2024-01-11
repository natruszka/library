using library.Enums;

namespace library.DTOs;

public class OrderDto
{
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public OrderStatus Status { get; set; }
}