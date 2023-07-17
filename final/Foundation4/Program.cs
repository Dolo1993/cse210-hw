 using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime date;
    protected int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string activityName = GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{date:dd MMM yyyy} {activityName} ({minutes} min) - Distance: {distance:F1} miles, Speed: {speed:F1} mph, Pace: {pace:F1} min per mile";
        return $"\n{summary}\n"; 
    }
}

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / minutes) * 60;
    }

    public override double GetPace()
    {
        return minutes / distance;
    }
}

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return minutes / speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / minutes) * 60;
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }
}

public class FitnessCenterApp
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>();

        // Create activities
        DateTime runningDate = new DateTime(2023, 7, 3);
        double runningDistance = 3.0;
        int runningMinutes = 30;
        activities.Add(new Running(runningDate, runningMinutes, runningDistance));

        DateTime cyclingDate = new DateTime(2023, 06, 7);
        double cyclingSpeed = 6.0;
        int cyclingMinutes = 30;
        activities.Add(new Cycling(cyclingDate, cyclingMinutes, cyclingSpeed));

        DateTime swimmingDate = new DateTime(2023, 01, 3);
        int swimmingLaps = 60;
        int swimmingMinutes = 30;
        activities.Add(new Swimming(swimmingDate, swimmingMinutes, swimmingLaps));

        // Display summaries
        foreach (Activity activity in activities)
        {
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }
    }
}
