using System;

namespace _05_Replacement
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt user for string
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter a string: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine();

            // prompt user for search string
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter search string: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string searchString = Console.ReadLine();

            // prompt user for replace string
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter replacement string: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string replacementString = Console.ReadLine();

            // splice strings
            string spliced = input.Replace(searchString, replacementString);

            // output spliced string
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The result is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(spliced + "\n");
            Console.ForegroundColor = ConsoleColor.White;


            // Example Output :
            /*
                Enter a string: I like hamburgers.
                Enter search string: .
                Enter replacement string:  and pizza!
                The result is: I like hamburgers and pizza!
            */
        }
    }
}
