using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine();
            Console.WriteLine("Hello, Welcome!");
            Console.Write("What is the magic number? ");
            string magicNumber = Console.ReadLine();
            int x = int.Parse(magicNumber);
            int guessCount = 0;
            bool guessedCorrectly = false;

            while (!guessedCorrectly)
            {
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                int y = int.Parse(guess);
                guessCount++;

                if (y < x)
                {
                    Console.WriteLine("Higher");
                }
                else if (y > x)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it.");
                    Console.WriteLine("Number of guesses: " + guessCount);
                    Console.WriteLine();
                    guessedCorrectly = true;
                }
            }

            Console.Write("Do you want to play again? (yes/no): "); 
             Console.WriteLine();
            string playAgainInput = Console.ReadLine().ToLower();

            if (playAgainInput != "yes")
            {
                playAgain = false;
            }
        }
    }
}