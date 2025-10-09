using System;

public class Journal
{
    
    public string _dateText;
    public string _prompt;
    public string _journalEntry;


// Journal format
    public Journal(string prompt, string entryText)
    {
        _dateText = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        _prompt = prompt;
        _journalEntry = entryText;

    }


    public void Display()
    {
        Console.WriteLine($"{_dateText}");
        Console.WriteLine($"{_prompt}");
        Console.WriteLine($"{_journalEntry}");
    }



}