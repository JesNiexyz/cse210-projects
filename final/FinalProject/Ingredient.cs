public class Ingredient
{
    private string _name;
    private Measurement _measurement;
    private string _category;
    private double _caloriesPerUnit;

    public Ingredient() { }

    public Ingredient(string name, Measurement measurement, string category, double caloriesPerUnit)
    {
        _name = name;
        _measurement = measurement;
        _category = category;
        _caloriesPerUnit = caloriesPerUnit;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Measurement MeasurementData
    {
        get => _measurement;
        set => _measurement = value;
    }

    public string Category
    {
        get => _category;
        set => _category = value;
    }

    public double caloriesPerUnit
    {
        get => _caloriesPerUnit;
        set => _caloriesPerUnit = value;
    }

    public string GetName() => _name;
    public Measurement GetMeasurement() => _measurement;
    //In Shopping List this will be used to group by categoy
    public string GetCategory() => _category;

    //Quantity of ingredients * calories per unit
    public double GetTotalCalories()
    {
        return _measurement.GetQuantity() * _caloriesPerUnit;
    }

    //Scales measurement class when scaling the recipe
    public void ScaleMeasurement(double factor)
    {
        _measurement.Scale(factor);
    }

    //Ingredient in a readable string
    public string Display()
    {
        return $"{_measurement} {_name}";
    }
}
