using System;

public class Person
{
    public string _giveName = "";
    public string _familyName = "";

    public Person()
    {

    }


    public void ShowEasternName()
    {
        Console.WriteLine($"{_familyName}, {_giveName}");
    }

    public void ShowWesternName()
    {
        Console.WriteLine($"{_giveName}, {_familyName}");
    }
}