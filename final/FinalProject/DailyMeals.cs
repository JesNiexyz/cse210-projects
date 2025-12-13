//Groups daily meals, each daya manages its own meals
//Reusable outside of MealPlan, calculates daily totals
//Meal Plan will later handle the week
public class DailyMeals
{
    //Stores recipes for the day, can be null
    private Recipe _breakfast;
    private Recipe _lunch;
    private Recipe _dinner;

    //Can be multiple snacks hence the List
    private List<Recipe> _snacks;

    public DailyMeals()
    {
        _snacks = new List<Recipe>();
    }

    // Add public properties for JSON serialization
    public Recipe Breakfast 
    { 
        get => _breakfast; 
        set => _breakfast = value; 
    }
    
    public Recipe Lunch 
    { 
        get => _lunch; 
        set => _lunch = value; 
    }
    
    public Recipe Dinner 
    { 
        get => _dinner; 
        set => _dinner = value; 
    }
    
    public List<Recipe> Snacks 
    { 
        get => _snacks; 
        set => _snacks = value ?? new List<Recipe>(); 
    }

    // assign a recipe to each meal / snack
    //Setters to keep data private a provide access to modify meals
    public void SetBreakfast(Recipe recipe) => _breakfast = recipe;
    public void SetLunch(Recipe recipe) => _lunch = recipe;
    public void SetDinner(Recipe recipe) => _dinner = recipe;
    public void AddSnack(Recipe recipe) => _snacks.Add(recipe);

    //Create empty list, check if meal exists and return a list for all meals for the day
    // Only add meals that exist
    public List<Recipe> GetAllMeals()
    {
        List<Recipe> allMeals = new List<Recipe>();
        if (_breakfast != null) allMeals.Add(_breakfast);
        if (_lunch != null) allMeals.Add(_lunch);
        if (_dinner != null) allMeals.Add(_dinner);
        //List method that adds multiple items at once
        allMeals.AddRange(_snacks);
        return allMeals;
    }

    //Calculates total calories in a day
    //Loops through meals in GetAllMeals calcualtes nutritional info and add calories to toal
    public double GetDailyCalories()
    {
        double total = 0;
        foreach (var meal in GetAllMeals())
        {
            //Returns Nutritional info object and returns the double
            //Calls methods, not needing to how nutrition is calculated or stored
            total += meal.CalculateNutrition().GetCalories();
        }
        return total;
    }

    //Formatted Daily Meals string
    public void Display()
    {
        //Checks if meals exist
        Console.WriteLine($"  Breakfast: {(_breakfast != null ? _breakfast.GetName() : "Not planned")}");
        Console.WriteLine($"  Lunch: {(_lunch != null ? _lunch.GetName() : "Not planned")}");
        Console.WriteLine($"  Dinner: {(_dinner != null ? _dinner.GetName() : "Not planned")}");
        Console.WriteLine($"  Total Calories: {GetDailyCalories():F0}");
    }

}