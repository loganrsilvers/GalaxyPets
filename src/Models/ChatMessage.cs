namespace GalaxyPets.Models;

public sealed record ChatMessage
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Content { get; set; } = "";
    public int ClubId { get; set; }
    public DateTime Timestamp { get; set; }
}
