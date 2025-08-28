using System.Text.Json.Serialization;

namespace DrinksInfo.Models;
internal class Category
{
    [JsonPropertyName("strCategory")]
    public string CategoryName { get; set; }

    public override string ToString()
    {
        return CategoryName;
    }
}

internal class CategoryResponse
{
    [JsonPropertyName("drinks")]
    public List<Category> categories { get; set; }
}