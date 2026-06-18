using System.ComponentModel.DataAnnotations;

namespace GalaxyPets.Models;

public class Item
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Category { get; set; } = string.Empty;

    public int Price { get; set; }

    [Required, MaxLength(200)]
    public string ImagePath { get; set; } = string.Empty;
}