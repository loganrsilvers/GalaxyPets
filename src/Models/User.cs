using System.ComponentModel.DataAnnotations;



namespace GalaxyPets.Models;



public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(256)]
    public string PasswordHash { get; set; } = string.Empty;

    public int Coins { get; set; } = 0;
    public bool IsOnline { get; set; } = false;
    public DateTime LastSeen { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties (Helps EF Core understand relationships)
    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    public ICollection<Score> Scores { get; set; } = new List<Score>();
}