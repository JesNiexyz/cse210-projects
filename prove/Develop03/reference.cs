using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse;

    //If reference is a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = verse;
        _lastVerse = verse;
    }
    //If reference is multiple verses
    public Reference(string book, int chapter, int firstVerse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }
    
    public string GetDisplayText()
    {   //Make's sure single verse reference or multiple verse reference are displayed
        if (_firstVerse == _lastVerse)
            return $"{_book} {_chapter}:{_firstVerse}";
        else
            return $"{_book} {_chapter}:{_firstVerse}-{_lastVerse}";
    }
}