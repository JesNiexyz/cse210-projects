using System.Security.Cryptography.X509Certificates;

public class ShoppingList
{
    //Dictionary; Key: FOod category, Value: List of ingredient objects
    private Dictionary<string, List<Ingredient>> _items;

    //Stores when shopping list is created
    private DateTime _generatedDate;

    public ShoppingList()
    {
        _items = new Dictionary<string, List<Ingredient>>();
        _generatedDate = DateTime.Now;
    }


    // Add this property if you haven't already
    public DateTime GeneratedDate 
    { 
        get => _generatedDate; 
        set => _generatedDate = value; 
    }

    //exports the shopping list data
    public ShoppingListData ExportData()
    {
        return new ShoppingListData
        {
            GeneratedDate = _generatedDate,
            Items = _items
        };
    }

    //imports the shopping list data
    public void ImportData(ShoppingListData data)
    {
        _generatedDate = data.GeneratedDate;
        _items = data.Items ?? new Dictionary<string, List<Ingredient>>();
    }

    //Add ingredients
    public void AddIngredient(Ingredient ingredient)
    {
        //Check if category is in dictionary
        string category = ingredient.GetCategory();

        //if category not in list, create a new list for said category
        if (!_items.ContainsKey(category))
        {
            _items[category] = new List<Ingredient>();
        }

        //Add ingredient to category's list
        _items[category].Add(ingredient);
    }

    // Add ingredients from a recipe to a shopping list
    public void AddRecipe(Recipe recipe)
    {
        //Loops all ingredients in recipe
        foreach (var ingredient in recipe.GetIngredients())
        {
            AddIngredient(ingredient);
        }
        //Merge duplicates
        CombineDuplicates();
    }
    //Returns entire dictionary and return categories with their ingredient list
    public Dictionary<string, List<Ingredient>> GroupByCategory()
    {
        return _items;
    }

    //Combine duplicate ingredients in a recipe
    public void CombineDuplicates()
    {
        //Loop through each food category
        foreach (var category in _items.Keys.ToList())
        {
            //Create new dictionary to track combined ingredients by name
            var ingredients = _items[category];
            var combined = new Dictionary<string, Ingredient>();

            //Loop through ingredients in that category
            foreach (var ingredient in ingredients)
            {
                // if ingredient exists in combined dictionary it doesn't add it in combined dictionary
                string name = ingredient.GetName();
                if (combined.ContainsKey(name))
                {
                    double existingQty = combined[name].GetMeasurement().GetQuantity();
                    double newQty = ingredient.GetMeasurement().GetQuantity();
                    combined[name].GetMeasurement().Scale(1.0);
                }
                else
                {
                    combined[name] = ingredient;
                }
            }
            _items[category] = combined.Values.ToList();
        }
    }

    public void Display()
    {
        Console.WriteLine($"\n{'=', -60}");
        Console.WriteLine($"SHOPPING LIST - Generated {_generatedDate.ToShortDateString()}");
        Console.WriteLine($"{'=', -60}");

        //Sorts catergories alphabetically
        foreach (var category in _items.Keys.OrderBy(k => k))
        {
            Console.WriteLine($"\n{category}");
            foreach (var ingredient in _items[category])
            {
                //Representative of a checkbox
                Console.WriteLine($" [ ] {ingredient.Display()}");
            }
        }
    }

    //This will be used for saving a file, copying etc
    public string ExportToString()
    {
        string output = $"Shopping List - {_generatedDate.ToShortDateString()}\n\n";

        foreach (var category in _items.Keys.OrderBy(k => k))
        {
            output += $"{category}:\n";
            foreach (var ingredient in _items[category])
            {
                output += $" [ ] {ingredient.Display()}\n";
            }
            output += "\n";
        }

        return output;
    }
}