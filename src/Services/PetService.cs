namespace GalaxyPets.Services;

using GalaxyPets.Models;

public class PetService
{
    public async Task<Pet?> GetUserPetAsync(string username)
    {
        await Task.Delay(10);
        return null;
    }

    public async Task AdoptPetAsync(Pet pet)
    {
        await Task.Delay(10);
    }
}

