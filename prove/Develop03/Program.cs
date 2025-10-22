using System;

class Program
{
    static void Main(string[] args)
    {
        // Reference reference = new Reference("Doctrine and Covenants", 4, 1, 7);
        // string text = "Now behold, a marvelous work is about to come forth among the children of men. Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day. Therefore, if ye have desires to serve God ye are called to the work; For behold the field is white already to harvest; and lo, he that thrusteth in his sickle with his might, the same layeth up in store that he perisheth not, but bringeth salvation to his soul; And faith, hope, charity and love, with an eye single to the glory of God, qualify him for the work. Remember faith, virtue, knowledge, temperance, patience, brotherly kindness, godliness, charity, humility, diligence. Ask, and ye shall receive; knock, and it shall be opened unto you. Amen.";
        // Scripture scripture = new Scripture(reference, text);

        ScriptureGenrator generator = new ScriptureGenrator();
        Scripture scripture = generator.GetRandomScripture();

        Console.Clear();

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");

            string input = Console.ReadLine(); // Waits for enter key

            if (input.ToLower() == "quit")
                break;

            Console.Clear();
            scripture.HideRandomWords(); //Hides words when enter is pressed

        }

        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram ending.");
    }
}