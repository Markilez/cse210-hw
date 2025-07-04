using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers from user until 0 is entered
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            int num;

            if (int.TryParse(input, out num))
            {
                if (num == 0)
                {
                    break; // End input collection
                }
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }

        // Core Requirements:

        // 1. Compute the sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}");

        // 2. Compute the average
        double average = (numbers.Count > 0) ? (double)sum / numbers.Count : 0;
        Console.WriteLine($"The average is: {average}");

        // 3. Find the maximum number
        if (numbers.Count > 0)
        {
            int maxNumber = numbers[0];
            foreach (int n in numbers)
            {
                if (n > maxNumber)
                {
                    maxNumber = n;
                }
            }
            Console.WriteLine($"The largest number is: {maxNumber}");
        }
        else
        {
            Console.WriteLine("No numbers entered to find max.");
        }

        // Stretch Challenge:

        // Find the smallest positive number (closest to zero)
        int? smallestPositive = null;
        foreach (int n in numbers)
        {
            if (n > 0)
            {
                if (smallestPositive == null || n < smallestPositive)
                {
                    smallestPositive = n;
                }
            }
        }
        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers entered.");
        }

        // Sort the list and display
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}