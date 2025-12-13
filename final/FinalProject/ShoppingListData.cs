// Add this class outside the Program class
public class ShoppingListData
{
    public DateTime GeneratedDate { get; set; }
    public Dictionary<string, List<Ingredient>> Items { get; set; }

    public ShoppingListData()
    {
        Items = new Dictionary<string, List<Ingredient>>();
    }
}