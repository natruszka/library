using System.ComponentModel.DataAnnotations;

namespace library.DTOs;

public class ReviewDto
{
    [Required]
    public int MemberId { get; set; }
    [Required]
    public int Rating { get; set; }
    public string? ReviewText { get; set; } 
    [Required]
    public string Isbn { get; set; } = null!;
}