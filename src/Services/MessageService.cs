namespace GalaxyPets.Services;

using GalaxyPets.Models;

public class MessageService
{
    public async Task<List<ChatMessage>> GetMessagesAsync(int clubId)
    {
        await Task.Delay(10);
        return new List<ChatMessage>();
    }

    public async Task SendMessageAsync(ChatMessage message)
    {
        await Task.Delay(10);
    }
}

