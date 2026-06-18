using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaxyPets.Models;

public class Score
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }

    [Required, MaxLength(50)]
    public string GameSlug { get; set; } = string.Empty;

    public int ScoreValue { get; set; } 
    public DateTime AwardedAt { get; set; } = DateTime.UtcNow;
}