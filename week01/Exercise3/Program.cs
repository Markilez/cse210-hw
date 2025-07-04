using System;

class Program
{
    static void Main()
    {
        // Initialize the random number generator
        Random randomGenerator = new Random();

        // Loop to allow replaying the game
        do
        {
            // Generate a random number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);
            int guessesCount = 0; // To keep track of guesses

            Console.WriteLine("I have picked a number between 1 and 100. Try to guess it!");

            int userGuess = 0;

            // Loop until the user guesses correctly
            while (true)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                // Convert input to integer with error handling
                if (int.TryParse(input, out userGuess))
                {
                    guessesCount++;

                    if (userGuess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else if (userGuess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                        break; // Exit the loop if guessed correctly
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            // Optional: inform the user how many guesses they made
            Console.WriteLine($"It took you {guessesCount} guesses.");

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain != "yes")
            {
                break; // Exit the outer loop if user doesn't want to continue
            }

        } while (true);

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}