namespace GalaxyPets.Services;

using GalaxyPets.Models;

public class ClosetService
{
    public async Task<List<Inventory>> GetUserInventoryAsync(string username)
    {
        await Task.Delay(10);
        return new List<Inventory>();
    }
}
