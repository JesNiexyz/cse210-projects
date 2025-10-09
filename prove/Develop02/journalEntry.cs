using System;

public class JournalBook
{
// For the class to work we need the format of the journal and the prompts to correspond with
    public List<Journal> _journalEntries = new List<Journal>();
    public PromptGenerator _promptGenerator = new PromptGenerator();


//Call Get new prompt
    public string GetNewPrompt()
    {
        return _promptGenerator.GetRandomPrompt();
    }
    // public void AddEntry(string content)
    // {
    //     string prompt = GetNewPrompt();
    //     Journal _entry = new Journal(prompt, content);
    //     _journalEntries.Add(_entry);
    // }


//This ensures that the entry we use will add the custom prompt instead of random prompts in the program.cs
    public void AddEntryWithCustomPrompt(string prompt, string content)
    {
        Journal entry = new Journal(prompt, content);
        _journalEntries.Add(entry);
    }

    //Function to display all entries
    public void DisplayAllEntries()
    {
        foreach (Journal entry in _journalEntries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
}