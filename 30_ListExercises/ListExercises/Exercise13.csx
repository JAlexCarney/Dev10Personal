using ListExercises.Game;
using System;
using System.Collections.Generic;

namespace ListExercises
{
    public class Program
    {
        private List<BoardGame> games = GameRepository.GetAll();

        public static void Main(string[] args)
        {
            Program instance = new Program();
            instance.Run();
        }

        private void PrintHeader(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine(new string('=', message.Length));
        }

        private void Run()
        {

            PrintHeader("Welcome to the Board Game Manager.");

            string input;
            do
            {
                PrintHeader("Menu");
                Console.WriteLine("1. Add a board game.");
                Console.WriteLine("2. Display all board games.");
                Console.WriteLine("3. Remove a board game.");
                Console.WriteLine("4. Exit");
                Console.Write("Select [1-4]: ");
                input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        // 1. Create a method that gathers user input via `console` to instantiate a BoardGame
                        // and then adds it to the `games` list.
                        // 2. Replace the the line of code below with a call to the method.
                        PrintHeader("Add a board game.");
                        break;
                    case "2":
                        // 3. Create a method to display all board games in the `games` list.
                        // 4. Replace the the line of code below with a call to the method.
                        PrintHeader("Display all board games.");
                        break;
                    case "3":
                        // 5. Stretch Goal: Create a method that allows the user to remove a board game from the
                        // `games` list with an index.
                        // 6. Replace the the line of code below with a call to the method.
                        PrintHeader("Remove a board game.");
                        break;
                    case "4":
                        PrintHeader("Goodbye.");
                        break;
                    default:
                        Console.WriteLine($"\nI don't understand '{input}'.");
                        break;
                }
            } while(input != "4");
        }
    }
}