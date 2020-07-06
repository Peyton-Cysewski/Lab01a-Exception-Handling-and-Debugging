using System;
using System.Dynamic;
using System.Net;

namespace Lab01a_Exception_Handling_and_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("It appears you made a mistake with one of your entries.");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
        }

        static void StartSequence()
        {
            try
            {
                // Intro message
                Console.WriteLine("Welcome to my game! Let\'s do some math!");
                // Function calls and input gathering
                Console.WriteLine("Enter a number that is greater than zero:");
                int input = Convert.ToInt32(Console.ReadLine());
                int[] userArray = new int[input];
                userArray = Populate(userArray);
                int userSum = GetSum(userArray);
                int userProduct = GetProduct(userArray, userSum);
                decimal userDecimal = GetQuotient(userProduct);
                // Summarizing all the computations of the functions
                Console.WriteLine($"Your array is of size: {input}");
                Console.Write("The numbers in your array are ");
                for (int i = 0; i < input; i++)
                {
                    Console.Write($"{userArray[i]}");
                    if (i != (input - 1))
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine($"\nThe sum of the array is {userSum}");
                Console.WriteLine($"{userSum} * {userProduct / userSum} = {userProduct}");
                Console.WriteLine($"{userProduct} / {userProduct / userDecimal } = {userDecimal}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int[] Populate(int[] userArray)
        {
            // Takes an empty array of known length and has the user populate it with integer values
            for (int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine($"Please enter a number ({i + 1}/{userArray.Length}):");
                string answer = Console.ReadLine();
                userArray[i] = Convert.ToInt32(answer);
            }
            return userArray;
        }

        static int GetSum(int[] userArray)
        {
            // Takes an array of integers and returns the summation of all its values
            int sum = 0;
            foreach (int num in userArray)
            {
                sum += num;
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low.");
            }
            return sum;
        }

        static int GetProduct(int[] userArray, int userSum)
        {
            // Has the user select a value that falls within the range of indices of the array, choose the value at said chosen index, and multiplies it with the sum of the array that is passed in
            try
            {
                Console.WriteLine($"Select a number between 1 and {userArray.Length}:");
                string answer = Console.ReadLine();
                int product;
                product = userArray[Convert.ToInt32(answer) - 1] * userSum;
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        static decimal GetQuotient(int userProduct)
        {
            // Gets a number from the user to divide the product by; the product value is passed in
            try
            {
                Console.WriteLine($"Enter a number by which to divide the product of {userProduct}:");
                string answer = Console.ReadLine();
                decimal num = decimal.Divide(Convert.ToDecimal(userProduct), Convert.ToDecimal(answer));
                return num;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
