using System;

class Program
{
    static void Main()
    {
        // Call DisplayWelcome to greet the user
        DisplayWelcome();

        // Prompt for user's name and store it
        string userName = PromptUserName();

        // Prompt for user's favorite number and store it
        int favoriteNumber = PromptUserNumber();

        // Calculate the square of the number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt user for their favorite number and return it
    static int PromptUserNumber()
    {
        int number;
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    // Function to square the number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the final message
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}