using System;

public class Scripture
{
    private Reference _reference;
    // Stores all the words in scripture text
    private List<Word> _words;
    // Breaks down scripture into individual Word object
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        //Split the scripture by spaces
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int randomAmountHidden = random.Next(2, 5); //Random number between 2 and 4

        // Creat a filtered list to contain words that aren't hidden 
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        //Hide minimum of randommountHidden/ remaining words visible
        int hiddenWords = Math.Min(randomAmountHidden, visibleWords.Count);
        
        // Loop and hide random words
        for (int i = 0; i < hiddenWords; i++)
        {
            //Hide random words, hide them and remove it from visiblewords list
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        // Convert WOrd objects into words or underscores then join them through spaces to make it look like a scripture
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        // Display reference and scripture 
        return $"{_reference.GetDisplayText()} {scriptureText}";
    }
    public bool AllWordsHidden()
    {
        // Checks if all words are hidden, returns true if all hidden
        return _words.All(w => w.IsHidden());
    }
}