using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();
        int addedNumber;
        while (true)
        {
            Console.Write("Add a number to the list (0 to finish): ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out addedNumber))
            {
                Console.WriteLine("Invalid number, please try again.");
                continue;
            }

            // stop when user enters 0 (do not add 0 to the list)
            if (addedNumber == 0)
            {
                break;
            }

            numberList.Add(addedNumber);
            Console.WriteLine($"Added number {addedNumber}");
        }

        int sum = numberList.Sum();
        float avg = numberList.Count > 0 ? (float)sum / numberList.Count : 0f;
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {avg}");
    }
}