using System;
using System.Threading;

public class Activity
{
    protected int duration;
    protected string description;

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting activity: {GetType().Name}");
        Console.WriteLine(description);
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Pause(3);
    }

    public virtual void EndActivity()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        Console.WriteLine($"Duration: {duration} seconds.");
        Pause(3);
    }

    public virtual void Run()
    {
        StartActivity();
        EndActivity();
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public int Duration => duration; // Expose duration for logging
}
