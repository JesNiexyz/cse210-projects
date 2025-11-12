using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square s1 = new Square("Red", 8);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Yellow", 3, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Blue", 7);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {Math.Round(area, 2)}.");
        }
    }
}