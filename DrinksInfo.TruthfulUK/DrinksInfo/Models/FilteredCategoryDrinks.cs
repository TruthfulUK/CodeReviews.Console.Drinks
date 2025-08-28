using System.Text.Json.Serialization;

namespace DrinksInfo.Models;
internal class FilteredCategoryDrinks
{
    [JsonPropertyName("strDrink")]
    public string Drink { get; set; }
    [JsonPropertyName("idDrink")]
    public string Id { get; set; }

    public override string ToString()
    {
        return Drink;
    }

}
internal class FilteredCategoryDrinksResponse
{
    [JsonPropertyName("drinks")]
    public List<FilteredCategoryDrinks> Drinks { get; set; }
}
