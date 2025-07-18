using System;
using System.Collections.Generic;
using System.Linq;

class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public List<int> Verses { get; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        Verses = new List<int> { verse };
    }

    public ScriptureReference(string book, int chapter, List<int> verses)
    {
        Book = book;
        Chapter = chapter;
        Verses = verses;
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{string.Join("-", Verses)}";
    }
}

class ScriptureWord
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public ScriptureWord(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

class Scripture
{
    public ScriptureReference Reference { get; }
    private List<ScriptureWord> Words { get; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        var unhiddenWords = Words.Where(w => !w.IsHidden).ToList();

        if (unhiddenWords.Count > 0)
        {
            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden);
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", Words.Select(w => w.Display())));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        // Example scripture
        ScriptureReference reference = new ScriptureReference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (!scripture.AllWordsHidden())
            {
                scripture.HideRandomWord();
            }
        }

        // Final display with all words hidden
        scripture.Display();
        Console.WriteLine("All words are now hidden. Thank you for using the Scripture Memorizer!");
    }
}
