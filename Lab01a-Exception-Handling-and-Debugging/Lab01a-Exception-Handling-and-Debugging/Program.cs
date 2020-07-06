using System;
using System.Dynamic;

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
                Console.WriteLine("This program has completed.")
            }
        }

        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Enter a number that is greater than zero:");
                int input = Convert.ToInt32(Console.ReadLine());
                int[] userArray = new int[input];
                userArray = Populate(userArray);
                int userSum = GetSum(userArray);
                int userProduct = GetProduct(userArray, userSum);
                decimal userDecimal = GetQuotient(userProduct);
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
            for (int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine($"Please enter a number ({i + 1}/{userArray.Length}):");
                userArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            return userArray;
        }
    }
}
