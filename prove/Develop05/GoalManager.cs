using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Display current score
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    // Display all goals
    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].DisplayGoal();
        }
        Console.WriteLine();
    }

    // Display goals with details
    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].DisplayDetails();
        }
        Console.WriteLine();
    }

    // Create a new goal
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Timed Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (choice == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }
        else if (choice == "4")
        {
            Console.Write("How many seconds should this goal last? ");
            int durationInSeconds = int.Parse(Console.ReadLine());

            TimedGoal goal = new TimedGoal(name, description, points, durationInSeconds);
            _goals.Add(goal);
            Console.WriteLine($"Timed goal started! You have {durationInSeconds} seconds.");
        }
    }

    // Record an event (user accomplished a goal)
    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice > 0 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];
            int pointsEarned = selectedGoal.RecordEvent();

            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");
            }
            else
            {
                Console.WriteLine("This goal is already complete or cannot be recorded.");
            }
        }
    }

    // Save goals to file
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Save the score first
            outputFile.WriteLine(_score);

            // Save each goal
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    // Load goals from file
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        // Clear existing goals
        _goals.Clear();

        // First line is the score
        _score = int.Parse(lines[0]);

        // Parse each goal
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            string goalType = parts[0];
            string[] details = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                bool isComplete = bool.Parse(details[3]);

                SimpleGoal goal = new SimpleGoal(name, description, points, isComplete);
                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                int bonus = int.Parse(details[3]);
                int target = int.Parse(details[4]);
                int amountCompleted = int.Parse(details[5]);

                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                _goals.Add(goal);
            }
            else if (goalType == "TimedGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                int durationInSeconds = int.Parse(details[3]);
                DateTime startTime = DateTime.Parse(details[4]);
                int timesCompleted = int.Parse(details[5]);

                TimedGoal goal = new TimedGoal(name, description, points, durationInSeconds, startTime, timesCompleted);
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}