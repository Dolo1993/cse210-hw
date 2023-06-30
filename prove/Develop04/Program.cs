using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome To Mindfulness Program");
        Console.WriteLine("-------------------");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            MindfulnessActivity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                    activity.Start();
                    break;
                case 2:
                    activity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                    activity.Start();
                    break;
                case 3:
                    activity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                    activity.Start();
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the mindfulness program. Goodbye!"); 
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}