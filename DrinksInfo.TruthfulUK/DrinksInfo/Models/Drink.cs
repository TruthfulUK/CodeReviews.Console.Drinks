namespace DrinksInfo.Models;
internal class Drink
{
    public string strDrink { get; set; }
    public string strCategory { get; set; }
    public string strInstructions { get; set; }
    public string strAlcoholic { get; set; }
    public string strGlass { get; set; }
    public string strIngredient1 { get; set; }
    public string strIngredient2 { get; set; }
    public string strIngredient3 { get; set; }
    public string strIngredient4 { get; set; }
    public string strIngredient5 { get; set; }
    public string strIngredient6 { get; set; }
    public string strIngredient7 { get; set; }
    public string strIngredient8 { get; set; }
    public string strIngredient9 { get; set; }
    public string strIngredient10 { get; set; }
    public string strIngredient11 { get; set; }
    public string strIngredient12 { get; set; }
    public string strIngredient13 { get; set; }
    public string strIngredient14 { get; set; }
    public string strIngredient15 { get; set; }
    public string strMeasure1 { get; set; }
    public string strMeasure2 { get; set; }
    public string strMeasure3 { get; set; }
    public string strMeasure4 { get; set; }
    public string strMeasure5 { get; set; }
    public string strMeasure6 { get; set; }
    public string strMeasure7 { get; set; }
    public string strMeasure8 { get; set; }
    public string strMeasure9 { get; set; }
    public string strMeasure10 { get; set; }
    public string strMeasure11 { get; set; }
    public string strMeasure12 { get; set; }
    public string strMeasure13 { get; set; }
    public string strMeasure14 { get; set; }
    public string strMeasure15 { get; set; }

    public List<IngredientMeasure> CreateIngredientList()
    {
        List<IngredientMeasure> output = new List<IngredientMeasure>();

        for (int i = 1; i <= 15; i++)
        {
            var curIngredient = GetType().GetProperty($"strIngredient{i}")?.GetValue(this) as string;

            var curMeasure = GetType().GetProperty($"strMeasure{i}")?.GetValue(this) as string;

            if (string.IsNullOrEmpty(curIngredient)) break;
            if (string.IsNullOrEmpty(curMeasure)) break;

            output.Add(new IngredientMeasure
            {
                Ingredient = curIngredient,
                Measure = curMeasure

            });
        }
        return output;
    }
}

internal class DrinksResponse
{
    public List<Drink> drinks { get; set; }
}

internal class IngredientMeasure
{
    public string Ingredient { get; set; }
    public string Measure {  get; set; }
}
