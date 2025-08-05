using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    public override void Run() // Use override to extend the base Run() method
    {
        StartActivity();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Pause(4);
            Console.WriteLine("Breathe out...");
            Pause(4);
        }
        EndActivity();
    }
}
