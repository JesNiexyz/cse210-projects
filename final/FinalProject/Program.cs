using System;

class Program
{
    static void Main(string[] args)
    {
        Measurement flourAmount = new Measurement(2, "cups");
        Ingredient flour = new Ingredient("Flour", flourAmount, "Pantry", 100);
        //ACCESS INFORMATION
        Console.WriteLine(flour.GetName());
        Console.WriteLine(flour.GetMeasurement());
        Console.WriteLine(flour.GetCategory());
        Console.WriteLine(flour.Display());

        // Calculate calories
        Console.WriteLine(flour.GetTotalCalories());

        //Scaling for a bigger recipe
        flour.ScaleMeasurement(2.0); //Double
        Console.WriteLine(flour.Display());
        Console.WriteLine(flour.GetTotalCalories());

        
    }
}