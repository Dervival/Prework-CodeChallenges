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
                Console.WriteLine("Problem #2: Leap Year Calculator");
                Console.WriteLine("Problem #3: Perfect Sequence");
                var problemNum = Console.ReadLine();
                bool validParse = Int32.TryParse(problemNum, out int problemNumber);
                if (!validParse)
                {
                    validSelect = false;
                    Console.WriteLine("I'm sorry, I don't understand that input. Can you please try again?");
                    Console.WriteLine();
                }
                switch (problemNumber)
                {
                    case 1:
                        Console.WriteLine("Accessing Array Max Result.");
                        arrayMaxResultWrapper();
                        break;
                    case 2:
                        Console.WriteLine("Accessing Leap Year Calculator.");
                        isLeapYearWrapper();
                        break;
                    case 3:
                        Console.WriteLine("Accessing Perfect Sequence");
                        perfectSequenceWrapper();
                        break;
                    case 4:
                        break;
                    default:
                        validSelect = false;
                        Console.WriteLine("I'm sorry, I don't understand that input. Can you please try again?");
                        //probably a better way to do this line break...
                        Console.WriteLine();
                        break;
                }
                //if (int.Parse(problemNumber) == 1)
                //{
                //    Console.WriteLine("Accessing Array Max Result.");
                //    arrayMaxResultWrapper();
                //}
                //else if(int.Parse(problemNumber) == 2)
                //{
                //    Console.WriteLine("Accessing Leap Year Calculator.");
                //    isLeapYearWrapper();
                //}
                //else if(int.Parse(problemNumber) == 3)
                //{
                //    Console.WriteLine("Accessing Perfect Sequence");
                //    perfectSequenceWrapper();
                //}
                //else
                //{
                //    validSelect = false;
                //    Console.WriteLine("I'm sorry, I don't understand that input. Can you please try again?");
                //    Console.WriteLine();
                //}
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

        static bool isLeapYear(int year)
        {
            if(year%400 == 0)
            {
                return true;
            }
            else if(year%100 == 0)
            {
                return false;
            }
            else if(year%4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isPerfectSequence(int[] array)
        {
            if(arraySum(array) == arrayMult(array))
            {
                return true;
            }
            return false;
        }

        static int arraySum(int[] array)
        {
            int sum = 0;
            for(int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static int arrayMult(int[] array)
        {
            int mult = 1;
            for (int i = 0; i < array.Length; i++)
            {
                mult *= array[i];
            }
            return mult;
        }

        static void perfectSequenceWrapper()
        {
            Console.WriteLine("Please type in an array of integers to determine if it's a perfect sequence.");
            Console.WriteLine("For instance, typing in [1, 2, 3]) will calculate the result " + isPerfectSequence(new int[] { 1, 2, 3 }) + ".");
            var userInput = Console.ReadLine();
            bool containsNeg = userInput.Contains("-");
            if (containsNeg)
            {
                Console.WriteLine("The array " + userInput + " is not a perfect sequence.");
                return;
            }
            //Strip off that first bracket
            if(userInput.Substring(0,1) == "[")
            {
                userInput = userInput.Substring(1);
            }
            //and its matching bracket
            if(userInput.Substring(userInput.Length-1) == "]")
            {
                userInput = userInput.Substring(0, userInput.Length - 1);
            }
            //userInput = userInput.Substring(1, userInput.Length - 2);
            var arrayInput = userInput.Split(",");
            int[] intArray = new int[arrayInput.Length];
            //Possible garbage between integers in the array that would be prepended to the int - keep trimming characters off the string array until it can be parsed into an integer
            for (int i = 0; i < arrayInput.Length; i++)
            {
                bool parsedIndex = Int32.TryParse(arrayInput[i], out int number);
                while (!parsedIndex)
                {
                    arrayInput[i] = arrayInput[i].Substring(1);
                    parsedIndex = Int32.TryParse(arrayInput[i], out number);
                }
                intArray[i] = number;
            }
            if (isPerfectSequence(intArray))
            {
                Console.WriteLine("The array [" + userInput + "] is a perfect sequence.");
                return;
            }
            else
            {
                Console.WriteLine("The array [" + userInput + "] is not a perfect sequence.");
                return;
            }
        }

        static void isLeapYearWrapper()
        {
            Console.WriteLine("Please enter a year to check.");
            string userYear = Console.ReadLine();
            int parseYear = -1;
            bool isValid = false;
            while (!isValid)
            {
                isValid = Int32.TryParse(userYear, out parseYear);
                if (!isValid)
                {
                    Console.WriteLine("I'm sorry, " + userYear + " is not a valid year. Please enter a valid year.");
                    userYear = Console.ReadLine();
                }
            }
            if (isLeapYear(parseYear))
            {
                Console.WriteLine(parseYear + " is a leap year.");
            }
            else
            {
                Console.WriteLine(parseYear + " is not a leap year.");
            }
        }

        static void arrayMaxResultWrapper()
        {
            int[] testArray = new int[] { 6, 4, 4, 1, 3 };
            int testNum = 4;
            Console.WriteLine("Please type in an array of five integers, and choose one of those integers.");
            Console.WriteLine("For instance, typing in [6, 4, 4, 1, 3], 4) will calculate the result " + arrayMaxResult(testArray, testNum) + ".");
            var userInput = Console.ReadLine();

            //Format of the input is [comma-delimited array], int - split into two arguments for the actual function
            var rawArrayInput = userInput.Split("],")[0];
            var arrayInput = rawArrayInput.Split(",");
            int[] parsedArray = new int[arrayInput.Length]; 
            //Possible garbage between integers in the array that would be prepended to the int - keep trimming characters off the string array until it can be parsed into an integer
            for (int i = 0; i < arrayInput.Length; i++)
            {
                //TryParse functionality mostly taken from https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netframework-4.7.2
                bool parsedIndex = Int32.TryParse(arrayInput[i], out int number);
                while (!parsedIndex) {
                    arrayInput[i] = arrayInput[i].Substring(1);
                    parsedIndex = Int32.TryParse(arrayInput[i], out number);
                }
                parsedArray[i] = number;
            }
            var numberInput = userInput.Split("],")[1];
            //Again, keep trimming the second value until it's parseable to being an integer
            bool parsedInput = Int32.TryParse(numberInput, out int input);
            while (!parsedInput)
            {
                numberInput = numberInput.Substring(1);
                parsedInput = Int32.TryParse(numberInput, out input);
            }
            Console.WriteLine("Result of arrayMaxResult(" + userInput + "): " + arrayMaxResult(parsedArray, input));
        }
    }
}
