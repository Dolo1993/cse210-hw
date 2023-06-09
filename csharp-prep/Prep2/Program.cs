using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Hello, Welcome!"); 
        Console.WriteLine();
        Console.Write("Please enter your final grade percentage here: ");
        string userGrade = Console.ReadLine();
        int grade = int.Parse(userGrade);
        string gradeLetter = "";
        string gradeSign = "";

        if (grade >= 90)
        {
            gradeLetter = "A";
        }
        else if (grade >= 80)
        {
            gradeLetter = "B";
        }
        else if (grade >= 70)
        {
            gradeLetter = "C";
        }
        else if (grade >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        int lastDigit = grade % 10;

        if (lastDigit >= 7 && gradeLetter != "F" && gradeLetter != "A")
        {
            gradeSign = "+";
        }
        else if (lastDigit < 3 && gradeLetter != "F")
        {
            gradeSign = "-";
        }

        if (gradeLetter == "A" && gradeSign == "+")
        {
            gradeSign = ""; 
        }
        else if (gradeLetter == "F")
        {
            gradeSign = ""; 
        }

        Console.WriteLine($"Your final grade is {gradeLetter}{gradeSign}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations for a job well done!"); 
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Oh! I am sorry, but you need to put more effort into your studies."); 
            Console.WriteLine();
        }
    }
}