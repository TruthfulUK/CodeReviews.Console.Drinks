namespace DrinksInfo.Models;
internal class FilteredCategoryDrinks
{
    public string strDrink { get; set; }
    public string idDrink { get; set; }

    public override string ToString()
    {
        return strDrink;
    }

}
internal class FilteredCategoryDrinksResponse
{
    public List<FilteredCategoryDrinks> drinks { get; set; }
}
