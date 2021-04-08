using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Play Rock Paper Scissors!");

            GameLogic game = new GameLogic(PromptForImplementation(1), PromptForImplementation(2));

            game.Shoot();
        }

        public static Player PromptForImplementation(int n) 
        {
            Console.WriteLine($"Enter implementation for player {n}.");
            Console.WriteLine("1. Random Picker");
            Console.WriteLine("2. Console Picker");
            Console.WriteLine("3. Always Rock");
            Console.WriteLine("4. Always Paper");
            Console.WriteLine("5. Always Scissors");
            Console.Write("\n");
            int choice = GetIntInRange("Enter Choice: ", 1, 5);
            Player player = null;
            switch (choice) 
            {
                case 1:
                    player = new Computer();
                    break;
                case 2:
                    player = new Human();
                    break;
                case 3:
                    player = new AlwaysChooses(Choice.ROCK);
                    break;
                case 4:
                    player = new AlwaysChooses(Choice.PAPER);
                    break;
                case 5:
                    player = new AlwaysChooses(Choice.SCISSORS);
                    break;

            }
            Console.WriteLine();
            return player;
        }

        public static int GetIntInRange(string prompt, int min, int max)
        {
            int output;
            string input;
            do
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (!int.TryParse(input, out output) || output < min || output > max);

            return output;
        }
    }
}
