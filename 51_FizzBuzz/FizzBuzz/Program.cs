using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuLoop();
        }

        static void MenuLoop() 
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to FizzBuzz");
                Console.WriteLine("===================");
                Console.WriteLine("");
                Console.WriteLine("Main Menu");
                Console.WriteLine("=========");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Enter a Specific Number");
                Console.WriteLine("2. List first n Numbers");
                Console.WriteLine("");
                int choice = GetInt("Enter choice: ");
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        int number = GetInt("Enter an int: ");
                        string fizzBuzz = FizzBuzz(number);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(fizzBuzz);
                        Console.WriteLine("");
                        break;
                    case 2:
                        int max = GetInt("Enter the max int: ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        for (int i = 0; i < max; i++)
                        {
                            Console.WriteLine($"{i,4}:{FizzBuzz(i)}");
                        }
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("Press Enter Too Continue...");
                Console.ReadLine();
            }
        }

        static int GetInt(string prompt) 
        {
            int output;
            while (true) 
            {
                Console.ResetColor();
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (int.TryParse(Console.ReadLine(), out output)) 
                {
                    Console.ResetColor();
                    return output;
                }
            }
        }

        static string FizzBuzz(int n) 
        {
            string output = n % 3 == 0 ? "Fizz " : "";
            return n % 5 == 0 ? output + "Buzz" : output;
        }
    }
}
