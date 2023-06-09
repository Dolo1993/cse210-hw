using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Hello, Welcome!"); 
        Console.Write("What is your first name? "); 
        string first_name = Console.ReadLine();  
 
        Console.Write("What is your last name? "); 
        string last_name = Console.ReadLine(); 
        Console.WriteLine(); 

        string uppercased_first_name = first_name.ToUpper();
        string uppercased_last_name = last_name.ToUpper();

        Console.WriteLine($"Your name is {uppercased_last_name}, {uppercased_first_name} {uppercased_last_name}."); 
        Console.WriteLine();

        
    } 
}