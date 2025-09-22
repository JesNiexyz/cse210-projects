using System;

class Program
{
    static void Main(string[] args)
    {
        //Randomly generates a number between 1-100
        Random randomnumber = new Random();
        int magicNumber = randomnumber.Next(1,101);

        int guessedNumber;

        do
        {
            Console.WriteLine("Guess the magic number ");
            guessedNumber = int.Parse(Console.ReadLine());

            if (guessedNumber > magicNumber)
            {
                Console.WriteLine("Lower");

            }
            else if (guessedNumber < magicNumber)
            {
                Console.WriteLine("Higher");

            }
            else
            {
                Console.WriteLine("Correct");

            }
        } while (guessedNumber != magicNumber);

    }
}