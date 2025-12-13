public class BreakfastRecipe : Recipe
{
    //Indicates if the recipe can be made quickly
    private bool _isQuickPrep;
    //What's the temperature, hot, cold, room temp
    private string _servingTemperature;

    public BreakfastRecipe(string name, string description, int prepTime, int cookTime, 
                           int servings, string difficulty, bool isQuickPrep, string servingTemperature)
        : base(name, description, prepTime, cookTime, servings, difficulty)
    {
        _isQuickPrep = isQuickPrep;
        _servingTemperature = servingTemperature;
        RecipeType = "Breakfast";
    }

    public bool IsQuickPrep 
    { 
        get => _isQuickPrep; 
        set => _isQuickPrep = value; 
    }

    public string ServingTemperature 
    { 
        get => _servingTemperature; 
        set => _servingTemperature = value; 
    }

    //Returns the meal type as breakfast
    public override string GetMealType()
    {
        return "Breakfast";
    }
    //Calculates nutritional info using breakfast specific percentages
    public override NutritionalInfo CalculateNutrition()
    {
        double totalCalories = 0;
        foreach (var ingredient in _ingredients)
        {
            totalCalories += ingredient.GetTotalCalories();
        }

        double protein = totalCalories * 0.20 / 4;
        double carbs = totalCalories * 0.60 / 4;
        double fat = totalCalories * 0.20 / 9;
        double fiber = totalCalories * 0.03 / 2;

        return new NutritionalInfo(totalCalories, protein, carbs, fat, fiber);
    }

    public override void Display()
    {
        base.Display();
        //if quickPrep true, return yes, is quickprep false, return no
        Console.WriteLine($"Quick prep: {(_isQuickPrep ? "Yes" : "No")}");
        Console.WriteLine($"Serving temperature: {_servingTemperature}");
    }
}