using System.Security.Cryptography.X509Certificates;

public abstract class Recipe
{

    //Protected allows the class and it's children to access
    protected string _name;
    protected string _description;
    protected List<Ingredient> _ingredients;
    protected int _preptime;
    protected int _cookTime;
    protected int _servings;
    protected string _difficulty;
    protected double _rating;

    // Add this property at the top of Recipe class
public string RecipeType { get; set; }

// Add public properties for all protected fields
public string Name 
{ 
    get => _name; 
    set => _name = value; 
}

public string Description 
{ 
    get => _description; 
    set => _description = value; 
}

public List<Ingredient> Ingredients 
{ 
    get => _ingredients; 
    set => _ingredients = value; 
}

public int PrepTime 
{ 
    get => _preptime; 
    set => _preptime = value; 
}

public int CookTime 
{ 
    get => _cookTime; 
    set => _cookTime = value; 
}

public int Servings 
{ 
    get => _servings; 
    set => _servings = value; 
}

public string Difficulty 
{ 
    get => _difficulty; 
    set => _difficulty = value; 
}

public double Rating 
{ 
    get => _rating; 
    set => _rating = value; 
}

// Add parameterless constructor
protected Recipe() { }

    public Recipe(string name, string description, int prepTime, int cookTime, int servings, string difficulty)
    {
        _name = name;
        _description = description;
        _preptime = prepTime;
        _cookTime = cookTime;
        _servings = servings;
        _difficulty = difficulty;
        _ingredients = new List<Ingredient>();  
        _rating = 0.0;
    }

    //Returns recipe name
    public string GetName() => _name;

    //Returns list of ingredient objects
    public List<Ingredient> GetIngredients() => _ingredients;

    //returns number of servings
    public int GetServings() => _servings;

    //Adds an ingredient to the recipe ingredient list
    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }

    //Sets user rating for the recipe, can be changed after setting
    public void SetRating(double rating)
    {
        _rating = rating;
    }

    // Adds prep and cook time together
    public int GetTotalTime()
    {
        return _preptime + _cookTime;
    }

    //Loops through ingredient objects to get a formatted string
    public string GetIngredientList()
    {
        string list ="";
        foreach (var ingredient in _ingredients)
        {
            list += " - " + ingredient.Display() + "\n";
        }
        return list;
    }


    // Calculates nutrition based on calories
    public virtual NutritionalInfo CalculateNutrition()
    {
        double totalCalories = 0;
        double totalProtein = 0;
        double totalCarbs = 0;
        double totalFat = 0;
        double totalFiber = 0;

        foreach (var ingredient in _ingredients)
        {
            totalCalories += ingredient.GetTotalCalories();
        }

    totalProtein = totalCalories * 0.15 / 4;
    totalCarbs = totalCalories * 0.55 / 4;
    totalFat = totalCalories * 0.30 / 9;
    totalFiber = totalCalories * 0.02 / 2;

    return new NutritionalInfo(totalCalories, totalProtein, totalCarbs, totalFat, totalFiber);

    }

    // Scales ingredient measurements when changing serving size
    //Loops ingredients and scales each one and updates servings based on the scale
    public void ScaleRecipe(int newServings)
    {
        double factor = (double)newServings / _servings;
        foreach (var ingredient in _ingredients)
        {
            ingredient.ScaleMeasurement(factor);
        }
        _servings = newServings;
    }

    // Used in the child classes to define the meal type
    public abstract string GetMealType();


    // Displaying the base recipe attributes
    public virtual void Display()
    {
        Console.WriteLine($"\n{'=',-50}");
        Console.WriteLine($"Recipe: {_name}");
        Console.WriteLine($"Type: {GetMealType()}");
        Console.WriteLine($"{'=', -50}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Difficulty: {_difficulty} | Rating: {_rating}/5.0");
        Console.WriteLine($"Prep Time: {_preptime} min | Cook Time: {_cookTime} min | Total: {GetTotalTime()} min");
        Console.WriteLine($"\nIngredients:");
        Console.WriteLine(GetIngredientList());
    }

}