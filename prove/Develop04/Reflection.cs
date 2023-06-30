using System;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(string _name, string _description) : base(_name, _description)
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();

        while (duration > 0)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            string question = questions[random.Next(questions.Length)];

            Console.WriteLine(prompt);
            Thread.Sleep(3000); 

            Console.WriteLine(question);
            Thread.Sleep(9000); 

            duration -= 8; 
        }
    }
}