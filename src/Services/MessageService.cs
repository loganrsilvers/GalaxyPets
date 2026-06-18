using GalaxyPets.Models;
using Microsoft.EntityFrameworkCore;
using GalaxyPets.Data;
namespace GalaxyPets.Services;

public class ChatService
{
    private readonly ApplicationDbContext _context;

    public ChatService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Translates: sendMessage.php logic
    public async Task<bool> SendMessageAsync(int clubId, int userId, string messageContent)
    {
        // Prevent empty messages from being saved
        if (string.IsNullOrWhiteSpace(messageContent)) 
            return false;

        var chatMessage = new ChatMessage
        {
            ClubId = clubId,
            UserId = userId,
            Message = messageContent,
            SentAt = DateTime.UtcNow
        };

        _context.ChatMessages.Add(chatMessage);
        await _context.SaveChangesAsync();
        
        return true;
    }

    // Translates: getMessages() from functions.php
    public async Task<List<ChatMessage>> GetMessagesAsync(int clubId)
    {
        return await _context.ChatMessages
            // .Include() tells EF Core to automatically fetch the User data 
            // tied to this message, so we can display their Username!
            .Include(m => m.User) 
            .Where(m => m.ClubId == clubId)
            .OrderBy(m => m.SentAt)
            .ToListAsync();
    }
}