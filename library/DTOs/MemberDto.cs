using System.ComponentModel.DataAnnotations;

namespace library.DTOs;

public class MemberDto
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public bool IsStaff { get; set; }
}