using System.Data;

public class NutritionalInfo
{
    private double _calories;
    private double _protein;
    private double _carbs;
    private double _fat;
    private double _fiber;

    public NutritionalInfo(double calories, double protein, double carbs, double fat, double fiber)
    {
        _calories = calories;
        _protein = protein;
        _carbs = carbs;
        _fat = fat;
        _fiber = fiber;
    }

    public double GetCalories() => _calories;

    public NutritionalInfo CalculatePerServing(int servings)
    {
        return new NutritionalInfo(
            _calories / servings,
            _protein / servings,
            _carbs / servings,
            _fat / servings,
            _fiber / servings
        );
    }

    public string GetMacroBreakdown()
    {
        return $"Protein: {_protein}g, Carbs: {_carbs}g, Fat: {_fat}g";
    }

    public void Display()
    {
        Console.WriteLine($"Calories: {_calories:F0}");
        Console.WriteLine($"Protein: {_protein:F1}g | Carbs: {_carbs:F1}g | Fat: {_fat:F1}g | Fiber: {_fiber:F1}g");
        
    }
}