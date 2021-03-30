using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            // declare a variable to store name
            string name;

            // prompt user for name
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            // print Hello, name variable value
            Console.WriteLine($"Hello {name}!");

            // prompt user for Tree Size
            Console.Write("How tall do you want your tree?: ");
            int size = int.Parse(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                // add whitespace before tree
                for (int j = 0; j < (size - i) / 2; j++)
                {
                    Console.Write(" ");
                }

                // draw tree line
                for (int j = i; j > 0; j--)
                {
                    if (random.NextDouble() < 0.5f)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("~");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("+");
                    }
                }
                Console.Write("\n");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
