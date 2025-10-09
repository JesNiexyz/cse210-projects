using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        JournalBook journalBook = new JournalBook();
        bool running = true;

        Console.WriteLine("Welcome to your Journal");

        while (running)
        {
            Console.WriteLine("\nChoose and option");
            Console.WriteLine("1.) Write an entry");
            Console.WriteLine("2.) View all entries");
            Console.WriteLine("3.) Save journal");
            Console.WriteLine("4.) Load journal");
            Console.WriteLine("5.) Quit ");

            Console.Write("Write the number corresponding for your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = journalBook.GetNewPrompt();
                    Console.WriteLine($"\n Prompt: {prompt}");
                    Console.Write("Your entry: ");
                    string entryText = Console.ReadLine();
                    journalBook.AddEntryWithCustomPrompt(prompt, entryText);
                    Console.WriteLine("Entry Saved");
                    break;

                case "2":
                    Console.WriteLine("\n Your journal entries:");
                    journalBook.DisplayAllEntries();
                    break;

                case "3":
                    Console.Write("\nEnter a filename to save (e.g., journal.txt): ");
                    string saveFileName = Console.ReadLine();
                    SaveJournalToFile(journalBook, saveFileName);
                    Console.WriteLine("Journal saved!");
                    break;

                case "4":
                    Console.Write("\nEnter the filename to load (e.g., journal.txt): ");
                    string loadFileName = Console.ReadLine();
                    LoadJournalFromFile(journalBook, loadFileName);
                    Console.WriteLine("Journal loaded!");
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;


            }
        }
    }


// Saves Journal
    static void SaveJournalToFile(JournalBook journalBook, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Journal entry in journalBook._journalEntries)
            {
                writer.WriteLine(entry._dateText);
                writer.WriteLine(entry._prompt);
                writer.WriteLine(entry._journalEntry);
                writer.WriteLine("---"); // separator
            }
        }
    }


    // Loads journal
    static void LoadJournalFromFile(JournalBook journalBook, string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        journalBook._journalEntries.Clear(); //Clear existing entries in the journal to avoid duplicates
        string[] lines = File.ReadAllLines(fileName); //Read all lines in the journal
        for (int i = 0; i < lines.Length; i += 4) // Loop through the journal in chunck of 4(date, prompt, entry, separator)
        {
            if (i + 2 < lines.Length) //Ensures there are enough lines for an entry (date, prompt, entry)
            {
                string date = lines[i];  //Saved date
                string prompt = lines[i + 1];  //Saved prompt
                string entryText = lines[i + 2];  //Saved entry


                Journal entry = new Journal(prompt, entryText); //Creates a new saved journal object
                entry._dateText = date; // overwrite with saved date
                journalBook._journalEntries.Add(entry); //Add reconstructed entry
                
            }
        }
    }
}