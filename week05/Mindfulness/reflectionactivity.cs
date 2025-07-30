using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectionActivity : Activity
{
    private Queue<string> prompts;
    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?"
    };

    public ReflectionActivity()
    {
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
        prompts = ShufflePrompts(new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
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

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Random rand = new Random();
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine(question);
            Pause(5);
        }
        EndActivity();
    }
}
