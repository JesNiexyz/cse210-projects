using System.Text.Json;
using System.IO;
class Program
{
    // Accessible Static methods
    static List<Recipe> recipeBook = new List<Recipe>();
    static ShoppingList shoppingList = new ShoppingList();
    static MealPlan weekPlan = new MealPlan(DateTime.Now);

    static void Main(string[] args)
    {
        AutoLoad();

        bool running = true;
        //Menu
        while (running)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║      RECIPE MANAGER & MEAL PLANNER     ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("\n1. Add a New Recipe");
            Console.WriteLine("2. View All Recipes");
            Console.WriteLine("3. Add Recipe to Shopping List");
            Console.WriteLine("4. Add Individual Ingredient to Shopping List");
            Console.WriteLine("5. View Shopping List");
            Console.WriteLine("6. Create Meal Plan");
            Console.WriteLine("7. View Meal Plan");
            Console.WriteLine("8. Save data");
            Console.WriteLine("9. Load Data");
            Console.WriteLine("10. Exit");
            Console.Write("\nSelect an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddRecipe();
                    break;
                case "2":
                    ViewRecipes();
                    break;
                case "3":
                    AddRecipeToShoppingList();
                    break;
                case "4":
                    AddIndividualIngredient();
                    break;
                case "5":
                    shoppingList.Display();
                    Pause();
                    break;
                case "6":
                    CreateMealPlan();
                    break;
                case "7":
                    weekPlan.Display();
                    Pause();
                    break;
                case "8":
                    SaveData();
                    break;
                case "9":
                    LoadData();
                    break;
                case "10":
                    //auto saving before exiting
                    Console.WriteLine("\nSaving data before exit......");
                    SaveData();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Pause();
                    break;
            }
        }
    }

    // Add recipe information including breakfast, dinner, dessert
    static void AddRecipe()
    {
        Console.Clear();
        Console.WriteLine("═══ ADD NEW RECIPE ═══\n");
        
        Console.Write("Recipe Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Description: ");
        string description = Console.ReadLine();
        
        Console.Write("Recipe Type (1=Breakfast, 2=Dinner, 3=Dessert): ");
        string type = Console.ReadLine();
        
        Console.Write("Prep Time (minutes): ");
        int prepTime = int.Parse(Console.ReadLine());
        
        Console.Write("Cook Time (minutes): ");
        int cookTime = int.Parse(Console.ReadLine());
        
        Console.Write("Number of Servings: ");
        int servings = int.Parse(Console.ReadLine());
        
        Console.Write("Difficulty (Easy/Medium/Hard): ");
        string difficulty = Console.ReadLine();
        
        Recipe recipe = null;
        
        if (type == "1")
        {
            Console.Write("Is this a quick prep recipe? (yes/no): ");
            bool quickPrep = Console.ReadLine().ToLower() == "yes";
            
            Console.Write("Serving Temperature (Hot/Cold/Room Temp): ");
            string temp = Console.ReadLine();
            
            recipe = new BreakfastRecipe(name, description, prepTime, cookTime, servings, difficulty, quickPrep, temp);
        }
        else if (type == "2")
        {
            Console.Write("Main Protein: ");
            string protein = Console.ReadLine();
            
            recipe = new DinnerRecipe(name, description, prepTime, cookTime, servings, difficulty, protein);
            
            Console.Write("Add side dishes? (yes/no): ");
            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("Enter side dishes (one per line, press Enter on empty line to finish):");
                while (true)
                {
                    string side = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(side)) break;
                    ((DinnerRecipe)recipe).AddSideDish(side);
                }
            }
        }
        else if (type == "3")
        {
            Console.Write("Sugar Content (grams): ");
            double sugar = double.Parse(Console.ReadLine());
            
            Console.Write("Serving Size: ");
            string servingSize = Console.ReadLine();
            
            recipe = new DessertRecipe(name, description, prepTime, cookTime, servings, difficulty, sugar, servingSize);
        }
        
        if (recipe != null)
        {
            Console.WriteLine("\n--- Add Ingredients ---");
            Console.WriteLine("Enter ingredients (press Enter on empty name to finish):\n");
            
            while (true)
            {
                Console.Write("Ingredient Name (or press Enter to finish): ");
                string ingName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingName)) break;
                
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                
                Console.Write("Unit (cups, tbsp, grams, etc.): ");
                string unit = Console.ReadLine();
                
                Console.Write("Category (Produce/Protein/Dairy/Pantry): ");
                string category = Console.ReadLine();
                
                Console.Write("Calories per unit: ");
                double calories = double.Parse(Console.ReadLine());
                
                Measurement measurement = new Measurement(quantity, unit);
                Ingredient ingredient = new Ingredient(ingName, measurement, category, calories);
                recipe.AddIngredient(ingredient);
                
                Console.WriteLine("Ingredient added!\n");
            }
            
            Console.Write("\nRating (0-5): ");
            double rating = double.Parse(Console.ReadLine());
            recipe.SetRating(rating);
            
            recipeBook.Add(recipe);
            Console.WriteLine($"\n✓ Recipe '{name}' added successfully!");
        }
        
        Pause();
    }

    //View recipes
    static void ViewRecipes()
    {
        Console.Clear();
        Console.WriteLine("═══ ALL RECIPES ═══\n");
        
        if (recipeBook.Count == 0)
        {
            Console.WriteLine("No recipes found. Add some recipes first!");
        }
        else
        {
            for (int i = 0; i < recipeBook.Count; i++)
            {
                Console.WriteLine($"\n[{i + 1}] {recipeBook[i].GetName()} ({recipeBook[i].GetMealType()})");
            }
            
            Console.Write("\nEnter recipe number to view details (or 0 to go back): ");
            int choice = int.Parse(Console.ReadLine());
            
            if (choice > 0 && choice <= recipeBook.Count)
            {
                recipeBook[choice - 1].Display();
                
                Console.WriteLine("\nNutritional Information:");
                recipeBook[choice - 1].CalculateNutrition().Display();
            }
        }
        
        Pause();
    }

    //Add recipes to shopping list
    static void AddRecipeToShoppingList()
    {
        Console.Clear();
        Console.WriteLine("═══ ADD RECIPE TO SHOPPING LIST ═══\n");
        
        if (recipeBook.Count == 0)
        {
            Console.WriteLine("No recipes available. Add some recipes first!");
        }
        else
        {
            for (int i = 0; i < recipeBook.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipeBook[i].GetName()}");
            }
            
            Console.Write("\nSelect recipe number: ");
            int choice = int.Parse(Console.ReadLine());
            
            if (choice > 0 && choice <= recipeBook.Count)
            {
                shoppingList.AddRecipe(recipeBook[choice - 1]);
                Console.WriteLine($"\n✓ '{recipeBook[choice - 1].GetName()}' added to shopping list!");
            }
        }
        
        Pause();
    }
    //Add ingredient without a single recipe
    static void AddIndividualIngredient()
    {
        Console.Clear();
        Console.WriteLine("═══ ADD INDIVIDUAL INGREDIENT ═══\n");
        
        Console.Write("Ingredient Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Quantity: ");
        double quantity = double.Parse(Console.ReadLine());
        
        Console.Write("Unit: ");
        string unit = Console.ReadLine();
        
        Console.Write("Category (Produce/Protein/Dairy/Pantry): ");
        string category = Console.ReadLine();
        
        Console.Write("Calories per unit (or 0 if unknown): ");
        double calories = double.Parse(Console.ReadLine());
        
        Measurement measurement = new Measurement(quantity, unit);
        Ingredient ingredient = new Ingredient(name, measurement, category, calories);
        
        shoppingList.AddIngredient(ingredient);
        Console.WriteLine($"\n✓ {name} added to shopping list!");
        
        Pause();
    }
    //Meal plan with specific days
    static void CreateMealPlan()
    {
        Console.Clear();
        Console.WriteLine("═══ CREATE MEAL PLAN ═══\n");
        
        if (recipeBook.Count == 0)
        {
            Console.WriteLine("No recipes available. Add some recipes first!");
            Pause();
            return;
        }
        
        Console.WriteLine("Select a day:");
        int dayNum = 0;
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            Console.WriteLine($"{dayNum}. {day}");
            dayNum++;
        }
        
        Console.Write("\nDay number: ");
        int dayChoice = int.Parse(Console.ReadLine());
        DayOfWeek selectedDay = (DayOfWeek)dayChoice;
        
        Console.Write("Meal type (breakfast/lunch/dinner/snack): ");
        string mealType = Console.ReadLine();
        
        Console.WriteLine("\nAvailable Recipes:");
        for (int i = 0; i < recipeBook.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipeBook[i].GetName()}");
        }
        
        Console.Write("\nSelect recipe number: ");
        int recipeChoice = int.Parse(Console.ReadLine());
        
        if (recipeChoice > 0 && recipeChoice <= recipeBook.Count)
        {
            weekPlan.AddMeal(selectedDay, mealType, recipeBook[recipeChoice - 1]);
            Console.WriteLine($"\n✓ Meal added to {selectedDay} {mealType}!");
        }
        
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void SaveData()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("═══ SAVING DATA ═══\n");

            //Save Recipes
            var recipeData = new List<object>();
            foreach (var recipe in recipeBook)
            {
                recipeData.Add(recipe);
            }

            string recipesJson = JsonSerializer.Serialize(recipeData, new JsonSerializerOptions {WriteIndented = true});
            File.WriteAllText("recipes.json", recipesJson);

            // Save shopping list
            var shoppingListData = shoppingList.ExportData();
            string shoppingListJson = JsonSerializer.Serialize(shoppingListData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("shopping_list.json", shoppingListJson);
            Console.WriteLine($"✓ Shopping list saved");
        
        // Save meal plan
            var mealPlanData = weekPlan.ExportData();
            string mealPlanJson = JsonSerializer.Serialize(mealPlanData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("meal_plan.json", mealPlanJson);
            Console.WriteLine($"✓ Meal plan saved");
        
            Console.WriteLine("\n✓ All data saved successfully!");

            Pause();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
            Pause();
        }
    }

    static void LoadData()
{
    try
    {
        Console.Clear();
        Console.WriteLine("═══ LOADING DATA ═══\n");

        int itemsLoaded = 0;
        
        // Load recipes
        if (File.Exists("recipes.json"))
        {
            string recipesJson = File.ReadAllText("recipes.json");
            var jsonDoc = JsonDocument.Parse(recipesJson);
            
            recipeBook.Clear();
            
            foreach (var element in jsonDoc.RootElement.EnumerateArray())
            {
                string recipeType = element.GetProperty("RecipeType").GetString();
                
                Recipe recipe = null;
                
                if (recipeType == "Breakfast")
                {
                    recipe = JsonSerializer.Deserialize<BreakfastRecipe>(element.GetRawText());
                }
                else if (recipeType == "Dinner")
                {
                    recipe = JsonSerializer.Deserialize<DinnerRecipe>(element.GetRawText());
                }
                else if (recipeType == "Dessert")
                {
                    recipe = JsonSerializer.Deserialize<DessertRecipe>(element.GetRawText());
                }
                
                if (recipe != null)
                {
                    recipeBook.Add(recipe);
                }
            }
            
            Console.WriteLine($"✓ Loaded {recipeBook.Count} recipes from recipes.json");
            itemsLoaded++;
        }

        //Load Meal plan
        if (File.Exists("meal_plan.json"))
        {
                string mealPlanJson = File.ReadAllText("meal_plan.json");
                var mealPlanData = JsonSerializer.Deserialize<MealPlanData>(mealPlanJson);
                weekPlan.ImportData(mealPlanData);
                Console.WriteLine($"✓ Meal plan loaded");
                itemsLoaded++;
        }
        if (itemsLoaded == 0)
        {
            Console.WriteLine("No saved data found.");
        }

        else
        {
            Console.WriteLine("Save Data loaded");
        }
        
        Pause();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading data: {ex.Message}");
        Pause();
    }
}

    static void AutoLoad()
    {
        try
        {
            if (File.Exists("recipes.json"))
            {
                string recipesJson = File.ReadAllText("recipes.json");
                var jsonDoc = JsonDocument.Parse(recipesJson);

                recipeBook.Clear();

                foreach(var element in jsonDoc.RootElement.EnumerateArray())
                {
                    string recipeType = element.GetProperty("RecipeType").GetString();

                    Recipe recipe = null;

                    if (recipeType == "Breakfast")
                    {
                        recipe = JsonSerializer.Deserialize<BreakfastRecipe>(element.GetRawText());
                    }
                    else if (recipeType == "Dinner")
                    {
                        recipe = JsonSerializer.Deserialize<DinnerRecipe>(element.GetRawText());
                    }
                    else if (recipeType == "Dessert")
                    {
                        recipe = JsonSerializer.Deserialize<DessertRecipe>(element.GetRawText());
                    }
                    if (recipe != null)
                    {
                        recipeBook.Add(recipe);
                    }
                }
            }
            // Load shopping list
            if (File.Exists("shopping_list.json"))
            {
                string shoppingListJson = File.ReadAllText("shopping_list.json");
                var shoppingListData = JsonSerializer.Deserialize<ShoppingListData>(shoppingListJson);
                shoppingList.ImportData(shoppingListData);
            }
        
            // Load meal plan
            if (File.Exists("meal_plan.json"))
            {
                string mealPlanJson = File.ReadAllText("meal_plan.json");
                var mealPlanData = JsonSerializer.Deserialize<MealPlanData>(mealPlanJson);
                weekPlan.ImportData(mealPlanData);
            }
        }
        catch
        {
            //Fails on autoload
        }
    }

    

    
}