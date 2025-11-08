using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;
    public ListingActivity() : base("Listing Activity", "This activity will help you list positive experiences you've had")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _count = 0;
    }
    
    public void Run()
    {
        DisplayStart();

        Console.WriteLine("\n\n");

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write("\n");
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("\n");

        // DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (!IsTimeUp())
        {
            Console.Write("> ");

            int remainingMs = (int)(_endTime - DateTime.Now).TotalMilliseconds;
            if (remainingMs <= 0) break;

            // Create a task that runs Console.ReadLine() in the background
            Task<string> readTask = Task.Run(() => Console.ReadLine());

            // Wait for either the user to press Enter OR the time to run out
            bool completed = readTask.Wait(remainingMs);
            if (completed)
            {
                _count++; //user input
            }
            else
            {
                Console.WriteLine(); // Move to next line after timeout
                break;
            }
        }

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEnd();
    }
}