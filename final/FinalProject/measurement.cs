public class Measurement
{

    private double _quantity;
    private string _unit;

    public Measurement() { }
    public Measurement(double quantity, string unit)
    {
        _quantity = quantity;
        _unit = unit;
    }

    public double Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public string Unit
    {
        get => _unit;
        set => _unit = value;
    }

    public double GetQuantity() => _quantity;
    public string GetUnit() => _unit;

    //Multiplies quantity by a factor
    public void Scale(double factor)
    {
        _quantity *= factor;
    }

// Transfers the quantity and unit to a readable string
    public override string ToString()
    {
        return $"{_quantity} {_unit}";
    }
}