using System;

class Program
{
    static void Main(string[] args) 
    {
        Console.WriteLine();
        Console.WriteLine("Hello, Welcome!");

        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        int number;
        int sum = 0;
        int count = 0;
        int max = int.MinValue;

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                if (number == 0)
                    break;

                sum += number;
                count++;
                max = Math.Max(max, number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        Console.WriteLine("You have finished entering your numbers.");

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The Average is: {average}");
            Console.WriteLine($"The largest number is: {max}"); 
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}