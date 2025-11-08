public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStart();

        Console.WriteLine("\n\n");
        Console.WriteLine("Begin breathing exercise:\n");

        


        // DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Console.WriteLine($"\nStarting {_duration} second breathing session... \n");
        // Thread.Sleep(1000);
        
        while (!IsTimeUp())
        {
            // TimeSpan remaining = endTime - DateTime.Now;
            // Console.WriteLine($"[{(int)remaining.TotalSeconds} seconds remaining]");

            Console.Write("Breathe in...");
            for (int i = 4; i > 0; i--)
            {
                Console.Write($"{i}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            
            Console.Write("\nNow breathe out...");
            for (int i = 6; i > 0; i--)
            {
                Console.Write($"{i}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine("\n");
        }
        
        DisplayEnd();
    }
}