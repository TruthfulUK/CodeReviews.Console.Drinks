using DrinksInfo.Controllers;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.Views;
internal class UserInterface
{
    private CategoriesController _categories = new CategoriesController();
    private DrinksController _drinks = new DrinksController();

    public async Task DisplayBarMenu()
    {

        var categoryList = await _categories.GetDrinkCategories();

        while (true)
        {
            Console.Clear();
            var selectedCategory = SelectCategory(categoryList);
            var drink = await SelectDrink(selectedCategory);
            DisplayDrink(drink);
        }
    }

    private Category SelectCategory(List<Category> categoryList)
    {
        AnsiConsole.MarkupLine("[blue]Bar Drink Menu[/] : Select a Category");

        var selectedCategory = AnsiConsole.Prompt(
        new SelectionPrompt<Category>()
        .AddChoices(categoryList));

        return selectedCategory;
    }

    private async Task<Drink> SelectDrink(Category selectedCategory)
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[blue]Bar Drink Menu[/] : Select a Drink");

        var drinks = await _drinks.GetDrinksByCategory(selectedCategory.CategoryName);

        var drinkChoice = AnsiConsole.Prompt(
        new SelectionPrompt<FilteredCategoryDrinks>()
        .AddChoices(drinks));

        return await _drinks.GetDrinkById(drinkChoice.Id);
    }

    private void DisplayDrink(Drink drink)
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"[blue]Bar Drink Menu[/] : {drink.Name} : Recipe & Instructions");

        var drinkTableHeader = new Table()
            .AddColumns("[blue]Drink Name[/]", "Category", "Glass Type", "Alcoholic?")
            .Expand()
            .MinimalDoubleHeadBorder();

        drinkTableHeader.AddRow(drink.Name, drink.Category, drink.Glass, drink.Alcoholic);

        var drinkTableBody = new Table()
            .AddColumns("Ingredient", "Measurement")
            .Expand()
            .HideRowSeparators();

        foreach (var i in drink.CreateIngredientList())
        {
            drinkTableBody.AddRow(i.Ingredient, i.Measure);
        }

        AnsiConsole.Write(drinkTableHeader);
        AnsiConsole.Write(drinkTableBody);
        AnsiConsole.MarkupLine($"[bold]Instructions:[/] {drink.Instructions}");

        var rule = new Rule();
        rule.RuleStyle("blue dim");
        AnsiConsole.Write(rule);
        AnsiConsole.MarkupLine($"Press any key to return to drink category selection ...");
        Console.ReadKey();
    }
}
