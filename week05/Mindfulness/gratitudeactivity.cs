using System;
using System.Collections.Generic;
using System.Linq;

public class GratitudeActivity : Activity
{
    private Queue<string> prompts;

    public GratitudeActivity()
    {
        description = "This activity will help you reflect on the positive aspects of your life.";
        prompts = ShufflePrompts(new List<string>
        {
            "What are three things you are grateful for today?",
            "Who is someone who made a positive impact on your life?",
            "What is a recent experience that brought you joy?"
        });
    }

    private Queue<string> ShufflePrompts(List<string> prompts)
    {
        Random rand = new Random();
        var shuffledPrompts = prompts.OrderBy(x => rand.Next()).ToList();
        return new Queue<string>(shuffledPrompts);
    }

    public void Run()
    {
        StartActivity();
        string prompt = prompts.Dequeue();
        Console.WriteLine(prompt);
        Pause(5);

        Console.WriteLine("List as many things as you can (type 'done' to finish):");
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
                break;
            items.Add(item);
        }
        Console.WriteLine($"You expressed gratitude for {items.Count} things.");
        EndActivity();
    }
}
