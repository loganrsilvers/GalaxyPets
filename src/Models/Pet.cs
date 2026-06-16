namespace GalaxyPets.Models;

public class Pet
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Expression { get; set; } = "regular";
    public string Planet { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
