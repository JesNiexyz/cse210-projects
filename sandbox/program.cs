using System;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person._giveName = "Joseph";
        person._familyName = "Smith";
        person.ShowWesternName();
        person.ShowEasternName();
    }
}