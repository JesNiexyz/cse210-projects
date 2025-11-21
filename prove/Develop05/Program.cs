using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        Console.WriteLine("Initiating Eternal Quest program");

        while (running)
        {
            manager.DisplayPlayerInfo();

            Console.WriteLine("Menu Options");
            Console.WriteLine("> 1.) Create New Goal");
            Console.WriteLine("> 2.) List Goals");
            Console.WriteLine("> 3.) Save Goals");
            Console.WriteLine("> 4.) Load Goals");
            Console.WriteLine("> 5.) Record Event");
            Console.WriteLine("> 6.) Quit");
            Console.Write("Select a choice from the menu ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoalNames();
                    break;
                case "3":
                    manager.SaveGoals();
                    break;
                case "4":
                    manager.LoadGoals();
                    break;
                case "5":
                    manager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("\n Ending Program");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            if (running)
            {
                Console.WriteLine("\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}