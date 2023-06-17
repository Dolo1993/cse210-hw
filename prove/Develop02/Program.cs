using System;
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        journal.Start();
    }
class Journal
{
    private List<string> prompts;
    private List<string> entries;

    public Journal()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        entries = new List<string>();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    Console.WriteLine();
                    break;
                case "2":
                    DisplayEntries();
                    Console.WriteLine();
                    break;
                case "3":
                    SaveJournalToFile();
                    Console.WriteLine();
                    break;
                case "4":
                    LoadJournalFromFile();
                    Console.WriteLine();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    private void WriteNewEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"> {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm},{prompt},{response}";
        entries.Add(entry);
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    private void DisplayEntries()
    {
        foreach (string entry in entries)
        {
            string[] parts = entry.Split(',');
            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];
            Console.WriteLine($"[{date}] Prompt: {prompt}\nResponse: {response}\n");
        }
    }

    private void SaveJournalToFile()
    {
        Console.Write("Enter the file name: ");
        string saveFileName = Console.ReadLine();

        try
        {
            using (var writer = new System.IO.StreamWriter(saveFileName))
            {
                foreach (string entry in entries)
                {
                    writer.WriteLine(entry);
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    private void LoadJournalFromFile()
    {
        Console.Write("Enter the file name: ");
        string loadFileName = Console.ReadLine();

        try
        {
            using (var reader = new System.IO.StreamReader(loadFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    entries.Add(line);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }
}

}