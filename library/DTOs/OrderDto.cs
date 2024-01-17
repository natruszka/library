using System.ComponentModel.DataAnnotations;
using library.Enums;

namespace library.DTOs;

public class OrderDto
{
    [Required]
    public int MemberId { get; set; }
    [Required]
    public int BookId { get; set; }
    [Required]
    public DateTimeOffset OrderDate { get; set; }
    [Required]
    public OrderStatus Status { get; set; }
}