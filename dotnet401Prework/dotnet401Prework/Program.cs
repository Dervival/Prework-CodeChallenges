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
            Console.WriteLine("Please type in an array of five integers, and choose one of those integers.");
            Console.WriteLine("For instance, typing in [6, 4, 4, 1, 3], 4) will calculate the result " + arrayMaxResult(testArray, testNum) + ".");
            var userInput = Console.ReadLine();
            var charArray = userInput.Split(",");

            //Format of the input is [comma-delimited array], int - split into two arguments for the actual function
            var rawArrayInput = userInput.Split("],")[0];
            var arrayInput = rawArrayInput.Split(",");
            int[] parsedArray = new int[arrayInput.Length]; 
            //Possible garbage between integers in the array that would be prepended to the int - keep trimming characters off the string array until it can be parsed into an integer
            for (int i = 0; i < arrayInput.Length; i++)
            {
                bool parsedIndex = Int32.TryParse(arrayInput[i], out int number);
                while (!parsedIndex) {
                    arrayInput[i] = arrayInput[i].Substring(1);
                    parsedIndex = Int32.TryParse(arrayInput[i], out number);
                }
                parsedArray[i] = number;
            }
            var numberInput = userInput.Split("],")[1];
            bool parsedInput = Int32.TryParse(numberInput, out int input);
            while (!parsedInput)
            {
                numberInput = numberInput.Substring(1);
                parsedInput = Int32.TryParse(numberInput, out input);
            }
            //Console.WriteLine(rawArrayInput.GetType() + " " + rawArrayInput);
            //for(int i = 0; i < arrayInput.Length; i++)
            //{
            //    Console.WriteLine("arrayInput at index i: " + arrayInput[i].GetType() + " " +arrayInput[i]);
            //}
            //for (int i = 0; i < parsedArray.Length; i++)
            //{
            //    Console.WriteLine("parsedArray at index i: " + parsedArray[i].GetType() + " " + parsedArray[i]);
            //}
            //Console.WriteLine(numberInput.GetType() + " " + numberInput);
            //Console.WriteLine(input.GetType() + " " + input);

            Console.WriteLine("Results of arrayMaxResult(" + userInput + "): " + arrayMaxResult(parsedArray, input));
        }
    }
}
