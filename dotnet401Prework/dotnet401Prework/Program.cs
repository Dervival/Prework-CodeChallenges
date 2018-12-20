using System;

namespace dotnet401Prework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            arrayMaxResultWrapper();
            Console.ReadLine();
        }

        static int arrayMaxResult(int[] targetArray, int chosenNumber)
        {
            //Given an array of integers and a chosen number, return a score consisting of the summation of the occurence of the number in the array. If no occurences exist, return 0.
            //Sample Input: [6, 4, 4, 1, 3], 4 -- Sample Output: 8
            //Sample Input: [1, 1, 3, 3, 5], 6 -- Sample Output: 0

            int value = 0;
            for(int i = 0; i < targetArray.Length; i++)
            {
                if (targetArray[i] == chosenNumber)
                {
                    value += chosenNumber;
                }
            }
            return value;
        }

        static void arrayMaxResultWrapper()
        {
            Console.WriteLine("Please type in an array of five integers, and choose one of those integers.");
            var userInput = Console.ReadLine();
            Console.WriteLine(userInput.GetType());
        }
    }
}
