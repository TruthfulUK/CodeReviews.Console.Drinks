using DrinksInfo.Models;
using DrinksInfo.Services;

namespace DrinksInfo.Controllers;
internal class DrinksController
{
    private CocktailService _client;

    public DrinksController()
    {
        _client = new CocktailService();
    }
    public async Task<List<FilteredCategoryDrinks>> GetDrinksByCategory(string category)
    {
        string endpoint = $"filter.php?c={category}";
        var response = await _client.GetAsync<FilteredCategoryDrinksResponse>(endpoint);

        return response?.Drinks ?? new List<FilteredCategoryDrinks>();
    }

    public async Task<Drink> GetDrinkById(string id)
    {
        string endpoint = $"lookup.php?i={id}";
        var response = await _client.GetAsync<DrinksResponse>(endpoint);

        return response?.drinks.First<Drink>() ?? new Drink();
    }
}
