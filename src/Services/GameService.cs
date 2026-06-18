using GalaxyPets.Models;
using Microsoft.EntityFrameworkCore;
using GalaxyPets.Data;
namespace GalaxyPets.Services;

public class GameService
{
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Maps to: scoreADDer.php
    // Adds currency to the user's account after they finish a game
    public async Task<int> AddCoinsAsync(int userId, int coinsToAdd)
    {
        // 1. Find the user by their ID
        var user = await _context.Users.FindAsync(userId);
        
        if (user != null)
        {
            // 2. Update their coins
            user.Coins += coinsToAdd;
            
            // 3. Save to the database
            await _context.SaveChangesAsync();
            return user.Coins;
        }
        
        return 0; // User not found
    }

    // Maps to: scoreSUBTACTer.php 
    // Removes currency (often used by the Shop or penalties)
    public async Task<int> SubtractCoinsAsync(int userId, int coinsToSubtract)
    {
        var user = await _context.Users.FindAsync(userId);
        
        if (user != null && user.Coins >= coinsToSubtract)
        {
            user.Coins -= coinsToSubtract;
            await _context.SaveChangesAsync();
            return user.Coins;
        }
        
        // Return current coins if they don't have enough to subtract, or 0 if null
        return user?.Coins ?? 0; 
    }

    // NEW FEATURE based on your schema
    // Saves a specific high score for a specific minigame
    public async Task<bool> SaveGameScoreAsync(int userId, string gameSlug, int scoreValue)
    {
        var newScore = new Score
        {
            UserId = userId,
            GameSlug = gameSlug,
            ScoreValue = scoreValue,
            AwardedAt = DateTime.UtcNow
        };

        _context.Scores.Add(newScore);
        await _context.SaveChangesAsync();
        
        return true;
    }
}