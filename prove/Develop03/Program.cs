using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        Reference reference = new Reference("Doctrine and Covenants", 58, 27);
        Scripture scripture = new Scripture(reference, "Verily I say, men should be anxiously engaged in a good cause, and do many things of their own free will, and bring to pass much righteousness.");
        
        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit");
            userInput = Console.ReadLine();

            if (userInput == "")
            {
                scripture.HideRandomWords();
            }
        }
    }
}





 