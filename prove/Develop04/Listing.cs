
public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string _name, string _description) : base(_name, _description)
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int itemCounter = 0;

        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine(prompt);
        Thread.Sleep(5000); 

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            itemCounter++;
        }

        Console.WriteLine($"Number of items listed: {itemCounter}");
    }
}