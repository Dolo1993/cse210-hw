using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(string _name, string _description) : base(_name, _description)
    {
    }

    protected override void PerformActivity()
    {
        int breatheInDuration = 1;
        int waitDuration = 2;
        int breatheOutDuration = 1;

        for (int i = 0; i < breatheInDuration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000); // Pause for 1 second
        }

        Thread.Sleep(waitDuration * 1000); 

        for (int i = 0; i < breatheOutDuration; i++)
        {
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);     
        }  

        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(3000); 
        }  

        {
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);  
        }   

        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(3000); 
        }   

        {
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);  
        }   



        Thread.Sleep(waitDuration * 2000); 
    }    
} 
