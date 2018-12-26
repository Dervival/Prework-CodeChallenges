using System;

namespace dotnet401Prework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validSelect = false;
            while (!validSelect) {
                validSelect = true;
                Console.WriteLine("Hello World!");
                Console.WriteLine("Please select one of the following by typing in its problem number.");
                Console.WriteLine("Problem #1: Array Max Result");
                var problemNumber = Console.ReadLine();
                if (int.Parse(problemNumber) == 1)
                {
                    Console.WriteLine("Accessing Array Max Result.");
                    arrayMaxResultWrapper();
                }
                else
                {
                    validSelect = false;
                    Console.WriteLine("I'm sorry, I don't understand that input. Can you please try again?");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Have a nice day.");
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
            int[] testArray = new int[] { 6, 4, 4, 1, 3 };
            int testNum = 4;
            Console.WriteLine("Results of arrayMaxResult([6, 4, 4, 1, 3], 4): " + arrayMaxResult(testArray, testNum));
            Console.WriteLine("Please type in an array of five integers, and choose one of those integers.");
            var userInput = Console.ReadLine();
            var charArray = userInput.Split(",");

            var arrayInput = userInput.Split("],")[0];
            var numberInput = userInput.Split("],")[1];
            Console.WriteLine(arrayInput.GetType() + " " + arrayInput);
            Console.WriteLine(numberInput.GetType() + " " + numberInput);
        }
    }
}
