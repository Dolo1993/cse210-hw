using System;

public abstract class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public MindfulnessActivity(string _name, string _description)
    {
        this.name = _name;
        this.description = _description;
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to {name} activity.");
        Console.WriteLine(description);

        // Prompt for duration and set it
        Console.Write("Enter duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());

        List<string> animinationStrings = new List<string>();
        animinationStrings.Add("|");
        animinationStrings.Add("/"); 
        animinationStrings.Add("-");
        animinationStrings.Add("\\");
        animinationStrings.Add("|");
        animinationStrings.Add("/"); 
        animinationStrings.Add("-");
        animinationStrings.Add("\\"); 

        foreach(string s in animinationStrings) 
        {
            Console.Write(s);
            Thread.Sleep(1000); 
            Console.Write("\b \b");
        }
         

        PerformActivity();

        Console.WriteLine($"Well done! You have completed the {name} activity in {duration} seconds ");
        // Thread.Sleep(3000); // Pause for 3 seconds 
        List<string> animinationString = new List<string>();
        animinationString.Add("|");
        animinationString.Add("/"); 
        animinationString.Add("-");
        animinationString.Add("\\");
        animinationString.Add("|");
        animinationString.Add("/"); 
        animinationString.Add("-");
        animinationString.Add("\\"); 

        foreach(string s in animinationStrings) 
        {
            Console.Write(s);
            Thread.Sleep(1000); 
            Console.Write("\b \b");
        }
    }

    protected abstract void PerformActivity();
}