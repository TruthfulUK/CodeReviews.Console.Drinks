using DrinksInfo.Models;
using DrinksInfo.Services;
using System.ComponentModel;

namespace DrinksInfo.Controllers;
internal class CategoriesController
{
    private CocktailService _client;

    public CategoriesController()
    {
        _client = new CocktailService();
    }

    public async Task<List<Category>> GetDrinkCategories()
    {
        string endpoint = "list.php?c=list";
        var response = await _client.GetAsync<CategoryResponse>(endpoint);

        return response?.categories ?? new List<Category>();          
    }
}
