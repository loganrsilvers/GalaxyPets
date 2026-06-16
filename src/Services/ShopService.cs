namespace GalaxyPets.Services;

using GalaxyPets.Models;

public class ShopService
{
    public async Task<List<Item>> GetShopItemsAsync()
    {
        await Task.Delay(10);
        return new List<Item>();
    }

    public async Task<int> GetUserPointsAsync(string username)
    {
        await Task.Delay(10);
        return 0;
    }

    public async Task PurchaseItemAsync(string username, int itemId)
    {
        await Task.Delay(10);
    }
}
