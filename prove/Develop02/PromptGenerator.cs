using System;


public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "Describe a fun activity you partook in:",
        "How productive were you today?",
        "What conversations did you have this week?",
        "What do you plan to do tomorrow?"
    };

    private Random _random = new Random();

// Ensure pulling up a random prompt
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
