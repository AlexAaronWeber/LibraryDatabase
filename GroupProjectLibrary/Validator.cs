using System;
namespace Validator
{
    public class Validator
    {
        //overloading a method -- give different return type or different parameter
        //normal version
        public static bool GetContinue()
        {
            bool result = true;
            while (true)
            {
                Console.Write("Would you like to continue? (y / n): ");
                string choice = Console.ReadLine().ToLower().Trim();
                if (choice == "y" || choice == "yes")
                {
                    result = true;
                    break;
                }
                else if (choice == "n" || choice == "no")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not valid");
                }
            }
            return result;
        }

        //overloaded version
        public static bool GetContinue(string message)
        {
            bool result = true;
            while (true)
            {
                Console.Write($"{ message} (y / n): ");
                string choice = Console.ReadLine().ToLower().Trim();
                if (choice == "y" || choice == "yes")
                {
                    result = true;
                    //Console.Clear();
                    break;
                }
                else if (choice == "n" || choice == "no")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not valid");
                }
            }
            return result;
        }

        //valid entry
        public static bool InRange(int value, int min, int max)
        {
            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int getUserNumber()
        {
            int result = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a number");
                    result = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }
        //ending two brackets
    }
}

