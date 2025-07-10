using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    public class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        public Entry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public override string ToString()
        {
            return $"{Date} | {Prompt} | {Response}";
        }
    }

    public class Journal
    {
        private List<Entry> entries;
        private static readonly string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void AddEntry(string response)
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Length)];
            Entry entry = new Entry(prompt, response);
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        entries.Add(new Entry(parts[1].Trim(), parts[2].Trim()) { Date = parts[0].Trim() });
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Journal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter your response:");
                        string response = Console.ReadLine();
                        journal.AddEntry(response);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.WriteLine("Enter filename to save:");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        break;
                    case "4":
                        Console.WriteLine("Enter filename to load:");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
