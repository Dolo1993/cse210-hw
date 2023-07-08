using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        GoalFileWriter goalFileWriter = new GoalFileWriter();
        GoalFileReader goalFileReader = new GoalFileReader();

        while (true)
        {  
            Console.WriteLine();
            Console.WriteLine("Eternal Quest Menu");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine(); 
        

            switch (input)
            {
                case "1":
                    Console.Write("Enter goal title: ");
                    string goalTitle = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    string goalDescription = Console.ReadLine();
                    Console.Write("Enter goal type 1. Simple 2. Eternal 3. Checklist: ");
                    string goalType = Console.ReadLine();

                    switch (goalType)
                    {
                        case "1":
                            Console.Write("Enter points for completing the goal: ");
                            int simplePoints = int.Parse(Console.ReadLine());
                            goalManager.AddGoal(new SimpleGoal(goalTitle, goalDescription, simplePoints));
                            break;
                        case "2":
                            Console.Write("Enter points for each recording: ");
                            int eternalPoints = int.Parse(Console.ReadLine());
                            goalManager.AddGoal(new EternalGoal(goalTitle, goalDescription, eternalPoints));
                            break;
                        case "3":
                            Console.Write("Enter points for each completion: ");
                            int checklistPoints = int.Parse(Console.ReadLine());
                            Console.Write("Enter number of required completions: ");
                            int requiredCompletions = int.Parse(Console.ReadLine());
                            Console.Write("Enter bonus points for completing all: ");
                            int bonusPoints = int.Parse(Console.ReadLine());
                            goalManager.AddGoal(new ChecklistGoal(goalTitle, goalDescription, checklistPoints, requiredCompletions, bonusPoints));
                            break;
                        default:
                            Console.WriteLine("Invalid goal type.");
                            break;
                    }

                    Console.WriteLine("Goal created.");
                    break;

                case "2":
                    goalManager.ListGoals();
                    break;

                case "3":
                    Console.Write("Enter file name to save goals: ");
                    string saveFileName = Console.ReadLine();
                    goalFileWriter.SaveGoals(saveFileName, goalManager.Goals);
                    Console.WriteLine("Goals saved.");
                    break;

                case "4":
                    Console.Write("Enter file name to load goals: ");
                    string loadFileName = Console.ReadLine();
                    goalManager.LoadGoals(goalFileReader.LoadGoals(loadFileName));
                    Console.WriteLine("Goals loaded.");
                    break;

                case "5":
                    goalManager.ListGoals();
                    Console.Write("Enter the index of the goal to record an event: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        if (index >= 0 && index < goalManager.Goals.Count)
                        {
                            Goal selectedGoal = goalManager.Goals[index];
                            Console.WriteLine($"Goal selected: {selectedGoal.Title}");
                            Console.WriteLine($"Description: {selectedGoal.Description}");
                            Console.WriteLine($"Points earned: {selectedGoal.Points}");
                            goalManager.RecordEvent(selectedGoal);
                            Console.WriteLine($"Congratulations! You earned {selectedGoal.Points} points.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid goal index.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid index.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Goodbye!"); 
                    Console.WriteLine();
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

public class GoalManager
{
    private List<Goal> goals;
    private int score;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(Goal goal)
    {
        if (!goal.IsCompleted)
        {
            goal.MarkComplete();
            score += goal.Points;

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
            {
                score += checklistGoal.BonusPoints;
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public void ListGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i}. {goal.GetProgress()} - {goal.Title} ({goal.Description})");
        }
    }

    public void LoadGoals(List<Goal> loadedGoals)
    {
        goals = loadedGoals;
    }

    public List<Goal> Goals
    {
        get { return goals; }
    }
}

class GoalFileWriter
{
    public void SaveGoals(string fileName, List<Goal> goals)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var goal in goals)
            {
                sw.WriteLine($"{goal.Title}|{goal.Description}|{goal.IsCompleted}|{goal.Points}");
            }
        }
    }
}

class GoalFileReader
{
    public List<Goal> LoadGoals(string fileName)
    {
        List<Goal> goals = new List<Goal>();
        if (File.Exists(fileName))
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        string title = parts[0];
                        string description = parts[1];
                        bool isCompleted = bool.Parse(parts[2]);
                        int points = int.Parse(parts[3]);

                        Goal goal;
                        if (isCompleted)
                        {
                            goal = new SimpleGoal(title, description, points);
                            goal.MarkComplete();
                        }
                        else
                        {
                            goal = new SimpleGoal(title, description, points);
                        }

                        goals.Add(goal);
                    }
                }
            }
        }
        return goals;
    }
}

public class ChecklistGoal : Goal
{
    public int PointsPerCompletion { get; set; }
    public int RequiredCompletions { get; set; }
    public int BonusPoints { get; set; }
    public int Completions { get; set; }

    public ChecklistGoal(string title, string description, int pointsPerCompletion, int requiredCompletions, int bonusPoints) : base(title, description)
    {
        PointsPerCompletion = pointsPerCompletion;
        RequiredCompletions = requiredCompletions;
        BonusPoints = bonusPoints;
        Completions = 0;
    }

    public override void MarkComplete()
    {
        Completions++;
        if (Completions >= RequiredCompletions)
            IsCompleted = true;
    }

    public override string GetProgress()
    {
        return IsCompleted ? $"Completed {Completions}/{RequiredCompletions} times" : $"Not completed yet";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points) :    base(title, description)
    {
        Points = points;
    }

    public override void MarkComplete()
    {
        // not happing here, because the enternal is never going to be completed
    }

    public override string GetProgress()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, int points) : base(title, description)
    {
        Points = points;
    }

    public override void MarkComplete()
    {
        IsCompleted = true;
    }

    public override string GetProgress()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}

public abstract class Goal
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int Points { get; set; }

    public Goal(string title, string description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
    }

    public abstract void MarkComplete();
    public abstract string GetProgress();
}