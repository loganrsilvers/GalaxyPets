using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaxyPets.Models;

public class Inventory
{
    [Key]
    public int Id { get; set; }

    public int PetId { get; set; }
    [ForeignKey("PetId")]
    public Pet? Pet { get; set; }

    public int ItemId { get; set; }
    [ForeignKey("ItemId")]
    public Item? Item { get; set; }

    public bool Equipped { get; set; } = false;
}