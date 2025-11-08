using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    Console.Clear();
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    Console.Clear();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("Ending program");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid Choice, try again");
                    break;
            }
        }
    }
}