using System;
using System.Text;

namespace _08_MethodTestAndExercises
{
    class Program
    {   
        static void Main(string[] args)
        {
            // Knock knock jokes
            Console.WriteLine("I've got some jokes for you!");

            // loop through multiple jokes (2)
            int numJokes = 2;
            string response = "";
            for (int i = 1; i <= numJokes; i++) 
            {
                // start joke
                Console.WriteLine("Knock Knock");

                // prompt for correct response
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.White;
                while (!(input.Contains("who") && input.Contains("there"))) 
                {
                    // That's not right!
                    Console.WriteLine("That's not right, Knock Knock");
                    input = Console.ReadLine().ToLower();
                }

                // select joke
                switch (i) 
                {
                    case 1:
                        // first joke first line
                        Console.WriteLine("Boo");
                        response = "boo who";
                        break;
                    case 2:
                        // Second joke first line
                        Console.WriteLine("who");
                        response = "who who";
                        break;
                }

                // prompt user for x who
                // prompt for correct response
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.White;
                while (!(input.Contains(response)))
                {
                    // That's not right!
                    Console.WriteLine("That's not right :P");
                    input = Console.ReadLine().ToLower();
                }

                // second line of joke
                switch (i)
                {
                    case 1:
                        // first joke second line
                        Console.WriteLine("Well, you don't have to cry about it!");
                        break;
                    case 2:
                        // Second joke second line
                        Console.WriteLine("I didn't know I was speaking to an owl.");
                        break;
                }

                // celebrate!
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"That was joke {i}! Wasn't it great!");
                Console.ForegroundColor = ConsoleColor.White;

                // MORE JOKES?
                if (i != numJokes) 
                {
                    Console.WriteLine($"\nHere's another one!\n");
                }
            }

        }
    }
}
