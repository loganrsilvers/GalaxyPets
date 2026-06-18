using System.ComponentModel.DataAnnotations;

namespace GalaxyPets.Models;

public class Club
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Slug { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string DisplayName { get; set; } = string.Empty;
}