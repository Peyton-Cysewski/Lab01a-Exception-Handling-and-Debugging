using System;

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


    }
}
