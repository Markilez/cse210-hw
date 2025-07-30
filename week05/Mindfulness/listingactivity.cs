using System;
using System.Collections.Generic;
using System.Linq;

public class ListingActivity : Activity
{
    private Queue<string> prompts;

    public ListingActivity()
    {
        description = "This activity will help you reflect on the good things in your life.";
        prompts = ShufflePrompts(new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
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

        Console.WriteLine("List as many items as you can (type 'done' to finish):");
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
                break;
            items.Add(item);
        }
        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}
