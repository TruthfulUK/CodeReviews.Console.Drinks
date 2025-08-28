using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrinksInfo.Services;
internal class CocktailService
{
    private readonly HttpClient _httpClient = new HttpClient()
    {
        BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
    };

    public async Task<T?> GetAsync<T> (string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request failed: {ex.Message}");
            return default;
        }
    }
}
