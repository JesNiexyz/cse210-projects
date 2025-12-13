public class DinnerRecipe : Recipe
{
    public DinnerRecipe() { }
    private string _mainProtein;

    //Collection of side dishes that can be accompined to the main dish
    private List<string> _sideDishes;

    // Initializes side dishes as empty because side dishes can be optional
    public DinnerRecipe (string name, string description, int prepTime, int cookTime, 
                        int servings, string difficulty, string mainProtein)
        : base(name, description, prepTime, cookTime, servings, difficulty)
    {
        _mainProtein = mainProtein;
        _sideDishes = new List<string>();
        RecipeType = "Dinner";
    }

    public string MainProtein
    {
        get => _mainProtein;
        set => _mainProtein = value;
    }

    public List<string> SideDishes
    {
        get => _sideDishes;
        set => _sideDishes = value;
    }

    public void AddSideDish(string sideDish)
    {
        _sideDishes.Add(sideDish);
    }

    public override string GetMealType()
    {
        return "Dinner";
    }
    // Returns a formatted string that contains a formatted a string with menu and side dishes
    public string GetCompleteMenu()
    {
        string menu = $"Main: {_name} ({_mainProtein})";
        if (_sideDishes.Count > 0)
        {
            menu += "\nSides:" + string.Join(", ", _sideDishes);
        }
        return menu;
    }
    // Dinner Specific nutrient distribution
    public override NutritionalInfo CalculateNutrition()
    {
        double totalCalories = 0;
        foreach (var ingredient in _ingredients)
        {
            totalCalories += ingredient.GetTotalCalories();
        }

        double protein = totalCalories * 0.30 / 4;
        double carbs = totalCalories * 0.40 / 4;
        double fat = totalCalories * 0.30 / 9;
        double fiber = totalCalories * 0.04 / 2;

        return new NutritionalInfo(totalCalories, protein, carbs, fat, fiber);
    }
    //Display recipe and dinner specific information
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Main Protein: {_mainProtein}");
        if (_sideDishes.Count > 0)
        {
            Console.WriteLine($"Side Dishes: {string.Join(", ", _sideDishes)}");
        }
    }
}