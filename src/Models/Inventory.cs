namespace GalaxyPets.Models;

public class Inventory
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string ItemType { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
