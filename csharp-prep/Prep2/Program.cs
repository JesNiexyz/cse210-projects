using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        // Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();

        // Use TryParse to avoid exceptions on bad input
        if (!float.TryParse(userInput, out float percentage))
        {
            Console.WriteLine("Invalid percentage input.");
            return;
        }

    string letterGrade = "";

        // determine letter grade (assign to existing variable)
        if (percentage >= 90.0f)
        {
            letterGrade = "A";
        }
        else if (percentage >= 80.0f)
        {
            letterGrade = "B";
        }
        else if (percentage >= 70.0f)
        {
            letterGrade = "C";
        }
        else if (percentage >= 60.0f)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

    Console.WriteLine($"Your grade is {letterGrade}");

        // Check pass or fail
    string classStatus;
        if (percentage >= 70.0f)
        {
            classStatus = "You passed the class";
        }
        else
        {
            classStatus = "You failed the class";
        }

    Console.WriteLine(classStatus);
    }
}