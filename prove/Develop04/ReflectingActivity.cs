public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectingActivity() : base("Reflecting Activity", "You will be given a series of prompts and ponder them based on your own experiences")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else: ",
            "Think of a time when you did something really difficult: ",
            "Think of a time when you helped someone in need: ",
            "Think of a time when you did something truly selfless: "
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }
    
    public void Run()
    {
        DisplayStart();

        //Timer space
        Console.WriteLine("\n\n");

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.Write("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("\nWhen you finish, press enter");
        Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions related to this experience");
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write("\n");
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.Clear();

        //Space for timer after clear
        Console.WriteLine("\n\n");

        // DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> usedQuestions = new List<string>();

        while (!IsTimeUp())
        {
            if (usedQuestions.Count == _questions.Count)
                usedQuestions.Clear();

            string question;
            do
            {
                question = _questions[random.Next(_questions.Count)];

            }
            while (usedQuestions.Contains(question));

            usedQuestions.Add(question);

            Console.Write($"\n> {question} ");

            // Display spinner for up to the remaining time (so spinner doesn't extend past the end time)
            int remainingMs = (int)(_endTime - DateTime.Now).TotalMilliseconds;
            if (remainingMs <= 0) break;
            int spinnerMs = Math.Min(15000, remainingMs);
            _timer.DisplaySpinner(spinnerMs);
        }

        DisplayEnd();
    }
}