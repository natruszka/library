using System.ComponentModel.DataAnnotations;

namespace library.DTOs;

public class AuthorDto
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
}