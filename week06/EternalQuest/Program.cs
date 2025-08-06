using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuest
{
    // Base class for all goals
    [Serializable]
    public abstract class Goal
    {
        public string Name { get; private set; }
        public int Points { get; protected set; }
        public bool IsComplete { get; protected set; }

        public Goal(string name)
        {
            Name = name;
            IsComplete = false;
        }

        public abstract void RecordEvent();
        public abstract void DisplayGoal();
        public abstract int GetPoints();
    }

    // Simple goal class
    [Serializable]
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name)
        {
            Points = points;
        }

        public override void RecordEvent()
        {
            IsComplete = true;
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"[ {(IsComplete ? "X" : " ")} ] {Name} - {Points} points");
        }

        public override int GetPoints()
        {
            return IsComplete ? Points : 0;
        }
    }

    // Eternal goal class
    [Serializable]
    public class EternalGoal : Goal
    {
        private int _recordCount;

        public EternalGoal(string name, int points) : base(name)
        {
            Points = points;
            _recordCount = 0;
        }

        public override void RecordEvent()
        {
            _recordCount++;
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"[ {(IsComplete ? "X" : " ")} ] {Name} - {_recordCount} times recorded - {GetPoints()} points");
        }

        public override int GetPoints()
        {
            return _recordCount * Points;
        }
    }

    // Checklist goal class
    [Serializable]
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;

        public ChecklistGoal(string name, int targetCount, int points) : base(name)
        {
            _targetCount = targetCount;
            Points = points;
            _currentCount = 0;
        }

        public override void RecordEvent()
        {
            if (_currentCount < _targetCount)
            {
                _currentCount++;
                if (_currentCount == _targetCount)
                {
                    IsComplete = true;
                    Points += 500; // Bonus for completing the checklist
                }
            }
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"[ {(IsComplete ? "X" : " ")} ] {Name} - Completed {_currentCount}/{_targetCount} times - {GetPoints()} points");
        }

        public override int GetPoints()
        {
            return IsComplete ? Points : _currentCount * Points;
        }
    }

    // Main program class
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalScore = 0;

        static void Main(string[] args)
        {
            LoadGoals();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEternal Quest Menu:");
                Console.WriteLine("1. Create Simple Goal");
                Console.WriteLine("2. Create Eternal Goal");
                Console.WriteLine("3. Create Checklist Goal");
                Console.WriteLine("4. Record Event");
                Console.WriteLine("5. Show Goals");
                Console.WriteLine("6. Show Total Score");
                Console.WriteLine("7. Save Goals");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateSimpleGoal();
                        break;
                    case "2":
                        CreateEternalGoal();
                        break;
                    case "3":
                        CreateChecklistGoal();
                        break;
                    case "4":
                        RecordEvent();
                        break;
                    case "5":
                        ShowGoals();
                        break;
                    case "6":
                        ShowTotalScore();
                        break;
                    case "7":
                        SaveGoals();
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateSimpleGoal()
        {
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter points for this goal: ");
            int points = int.Parse(Console.ReadLine());
            goals.Add(new SimpleGoal(name, points));
        }

        static void CreateEternalGoal()
        {
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter points for each recording: ");
            int points = int.Parse(Console.ReadLine());
            goals.Add(new EternalGoal(name, points));
        }

        static void CreateChecklistGoal()
        {
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter target number of completions: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter points for each recording: ");
            int points = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, targetCount, points));
        }

        static void RecordEvent()
        {
            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < goals.Count)
            {
                goals[index].RecordEvent();
                totalScore += goals[index].GetPoints();
                Console.WriteLine($"Recorded event for {goals[index].Name}. Total score: {totalScore}");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void ShowGoals()
        {
            Console.WriteLine("Current Goals:");
            foreach (var goal in goals)
            {
                goal.DisplayGoal();
            }
        }

        static void ShowTotalScore()
        {
            Console.WriteLine($"Total Score: {totalScore}");
        }

        static void SaveGoals()
        {
            string jsonString = JsonSerializer.Serialize(goals);
            File.WriteAllText("goals.json", jsonString);
            Console.WriteLine("Goals saved successfully.");
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.json"))
            {
                string jsonString = File.ReadAllText("goals.json");
                goals = JsonSerializer.Deserialize<List<Goal>>(jsonString);
                Console.WriteLine("Goals loaded successfully.");
            }
        }
    }
}
