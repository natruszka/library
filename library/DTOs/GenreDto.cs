using System.ComponentModel.DataAnnotations;

namespace library.DTOs;

public class GenreDto
{
    [Required]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}