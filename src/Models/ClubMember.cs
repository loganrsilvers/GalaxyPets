using System.ComponentModel.DataAnnotations;
namespace GalaxyPets.Models;

public class ClubMember
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public int ClubId { get; set; }
    public Club? Club { get; set; }
}