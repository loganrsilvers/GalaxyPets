
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaxyPets.Models;

public class ChatMessage
{
    [Key]
    public int Id { get; set; }

    public int ClubId { get; set; }
    [ForeignKey("ClubId")]
    public Club? Club { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }

    [Required, MaxLength(500)]
    public string Content { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty; 
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
