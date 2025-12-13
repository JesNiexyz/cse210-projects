public class DessertRecipe: Recipe
{
    public DessertRecipe() { }
    private double _sugarContent;
    private string _servingSize;

    public DessertRecipe(string name, string description, int prepTime, int cookTime, 
                         int servings, string difficulty, double sugarContent, string servingSize)
        : base(name, description, prepTime, cookTime, servings, difficulty)
    {
        _sugarContent = sugarContent;
        _servingSize = servingSize;
        RecipeType = "Dessert" ;
    }

    public double SugarContent
    {
        get => _sugarContent;
        set => _sugarContent = value;
    }

    public string ServingSize
    {
        get => _servingSize;
        set => _servingSize = value;
    }

    public override string GetMealType()
    {
        return "Dessert";
    }

    // Calculates sweetness level
    public string GetSweetnessLevel()
    {
        if (_sugarContent < 20) return "Lightly Sweet";
        if (_sugarContent < 40) return "Moderately Sweet";
        return "Very Sweet";
    }

    // Uses specific dessert calculations
    public override NutritionalInfo CalculateNutrition()
    {
        double totalCalories = 0;
        foreach (var ingredient in _ingredients)
        {
            totalCalories += ingredient.GetTotalCalories();
        }

        double protein = totalCalories * 0.05 / 4;
        double carbs = totalCalories * 0.70 / 4;
        double fat = totalCalories * 0.25 / 9;
        double fiber = totalCalories * 0.01 / 2;

        return new NutritionalInfo(totalCalories, protein, carbs, fat, fiber);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Sugar Content {_sugarContent}g per serving");
        Console.WriteLine($"Serving Size: {_servingSize}");
        Console.WriteLine($"SweetnessLevel: {GetSweetnessLevel()}");
    }
}