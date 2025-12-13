public class MealPlan
{
    //Date the meal plan starts
    private DateTime _weekStartDate;
    //Dictionary: Key: DayOfWeek stored in a Enum, Value: DailyMeals object for that day
    private Dictionary<DayOfWeek, DailyMeals> _dailyMeals;

    //Stores date, create empty dictionary, loop through days of the week
    //For each day create a new DailyMeal Object

    //Parameterless constructor
    public MealPlan()
    {
        _weekStartDate = DateTime.Now;
        _dailyMeals = new Dictionary<DayOfWeek, DailyMeals>();

        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            _dailyMeals[day] = new DailyMeals();
        }
    }
    public MealPlan(DateTime startDate)
    {
        _weekStartDate = startDate;
        _dailyMeals = new Dictionary<DayOfWeek, DailyMeals>();

        //Gets all DateofWeek key values and assigns each one to a day variable
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            _dailyMeals[day] = new DailyMeals();
        }
    }

    // Add public properties for serialization
    public DateTime WeekStartDate 
    { 
        get => _weekStartDate; 
        set => _weekStartDate = value; 
    }

    // Add methods to export/import data
    public MealPlanData ExportData()
    {
        var data = new MealPlanData
        {
            WeekStartDate = _weekStartDate,
            DailyMealsData = new Dictionary<string, DailyMeals>()
        };

        foreach (var kvp in _dailyMeals)
        {
            data.DailyMealsData[kvp.Key.ToString()] = kvp.Value;
        }

        return data;
    }

    public void ImportData(MealPlanData data)
    {
        _weekStartDate = data.WeekStartDate;
        _dailyMeals.Clear();

        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            string dayKey = day.ToString();
            if (data.DailyMealsData.ContainsKey(dayKey))
            {
                _dailyMeals[day] = data.DailyMealsData[dayKey];
            }
            else
            {
                _dailyMeals[day] = new DailyMeals();
            }
        }
    }

    
    //Method to build a meal plan, adds recipe to a meal slot to a specific day
    public void AddMeal(DayOfWeek day, string mealType, Recipe recipe)
    {
        mealType = mealType.ToLower();
        if (mealType == "breakfast")
            _dailyMeals[day].SetBreakfast(recipe);
        else if (mealType == "lunch")
            _dailyMeals[day].SetLunch(recipe);
        else if (mealType == "dinner")
            _dailyMeals[day].SetDinner(recipe);
        else if (mealType == "snack")
            _dailyMeals[day].AddSnack(recipe);
    }

    //Returns daily Meals for a specific day
    public DailyMeals GetMealsForDay(DayOfWeek day)
    {
        return _dailyMeals[day];
    }

    //
    public ShoppingList GenerateShoppingList()
    {
        ShoppingList list = new ShoppingList();

        foreach(var dailyMeal in _dailyMeals.Values)
        {
            foreach (var recipe in dailyMeal.GetAllMeals())
            {
                foreach (var ingredient in recipe.GetIngredients())
                {
                    list.AddIngredient(ingredient);
                }
            }
        }

        list.CombineDuplicates();
        return list;
    }

    // Calcualtes nutrition for the entire week by summing all meals
    public NutritionalInfo GetWeeklyNutrition()
    {
        double totalCalories = 0;
        double totalProtein = 0;
        double totalCarbs = 0;
        double totalFat = 0;
        double totalFiber = 0;
        //For each day get all recipes
        foreach (var dailyMeal in _dailyMeals.Values)
        {   //For each recipe calculate nutrtion
            foreach (var recipe in dailyMeal.GetAllMeals())
            {
                var nutrition = recipe.CalculateNutrition();
                //Add calories to total
                totalCalories += nutrition.GetCalories();
            }
        }
        //Return nutritional total
        return new NutritionalInfo(totalCalories, totalProtein, totalCarbs, totalFat, totalFiber);

    }

    public void Display()
    {
        Console.WriteLine($"\n{'=',-60}");
        Console.WriteLine($"MEAL PLAN - Week of {_weekStartDate.ToShortDateString()}");
        Console.WriteLine($"{'=', -60}");
        // Loops through enum values, displays day name and call that day's display method
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            Console.WriteLine($"\n{day}:");
            _dailyMeals[day].Display();
        }
    }
}