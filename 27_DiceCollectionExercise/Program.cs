using System;
using System.Collections.Generic;

namespace DiceCollectionExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> rolls = new List<int>();
            Dictionary<int, int> rollStats = new Dictionary<int, int>();
            Random random = new Random();

            for (int i = 2; i <= 12; i++) 
            {
                rollStats.Add(i, 0);
            }
            
            for (int i = 0; i < 100; i++) 
            {
                int roll = random.Next(1, 7) + random.Next(1, 7);
                rolls.Add(roll);
                rollStats[roll]++;
            }

            bool running = true;
            while (running) 
            {
                Console.Clear();
                ConsoleIO.WriteWithColor("1. View Rolls\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("2. View Top Roll Stat\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("3. Remove a roll\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("4. Exit\n\n", ConsoleColor.Yellow);

                int choice = ConsoleIO.GetIntInRange("Enter Choice: ", 1, 4);

                switch (choice) 
                {
                    case 1: // View Rolls
                        for (int i = 0; i < rolls.Count; i++) 
                        {
                            ConsoleIO.WriteWithColor($"{i+1} : {rolls[i]}\n", ConsoleColor.Yellow);
                        }
                        break;
                    case 2: // View Top Roll Stat
                        int topRollStat = -1;
                        int topRollStatIndex = -1;
                        for (int i = 2; i <= 12; i++) 
                        {
                            if (topRollStat < rollStats[i]) 
                            {
                                topRollStat = rollStats[i];
                                topRollStatIndex = i;
                            }
                        }
                        ConsoleIO.WriteWithColor($"Top roll result is! Rolled {topRollStatIndex}, {topRollStat} times!\n", ConsoleColor.Yellow);
                        break;
                    case 3: // Remove a roll
                        Console.WriteLine();
                        int indexToRemove = ConsoleIO.GetIntInRange($"Enter index to remove [1, {rolls.Count}]", 1, rolls.Count) - 1;
                        rollStats[rolls[indexToRemove]]--;
                        rolls.RemoveAt(indexToRemove);
                        break;
                    case 4:
                        running = false;
                        break;
                }

                Console.WriteLine();
                ConsoleIO.PromptContinue();
            }
            ConsoleIO.WriteWithColor("\nGoodbye!\n", ConsoleColor.Yellow);
        }
    }
}
