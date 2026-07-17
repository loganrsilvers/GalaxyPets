using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaxyPets.Models;

public class Pet
{
    [Key]
    public int Id { get; set; }

    public int OwnerId { get; set; }
    [ForeignKey("OwnerId")]
    public User? Owner { get; set; } 

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Species { get; set; } = string.Empty;

    [MaxLength(20)] // Reasonable limit for a color name
    public string Color { get; set; } = "Default";

    [MaxLength(20)] // Reasonable limit for an expression name
    public string Expression { get; set; } = "regular";

    public int? PlanetId { get; set; }
    [ForeignKey("PlanetId")]
    public Planet? Planet { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime Birthday { get; set; } = DateTime.UtcNow;
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}