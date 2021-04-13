using System;
using System.Collections.Generic;
using System.Text;

namespace ShopKeep
{
    public static class ConsoleIO
    {
        /// <summary>
        /// Displays a string using a color instead of just white
        /// </summary>
        /// <param name="toWrite">The string to display</param>
        /// <param name="color">The color to display it in</param>
        public static void WriteWithColor(string toWrite, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(toWrite);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Waits for user to enter any key
        /// </summary>
        public static void PromptContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompts the user for a string and returns once the user enters a valid one
        /// </summary>
        /// <param name="prompt">The prompt that the user sees</param>
        /// <returns>The first valid string that the user enters</returns>
        public static string GetString(string prompt)
        {
            string output;
            do
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                output = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (string.IsNullOrEmpty(output));
            return output;
        }

        /// <summary>
        /// repeatedly Prompts the user for an int and only returns once they have
        /// entered a valid int in the given range
        /// </summary>
        /// <param name="prompt">The prompt shown to the user</param>
        /// <param name="min">The smallest valid int</param>
        /// <param name="max">The largest valid int</param>
        /// <returns>The first valid int entered by the user</returns>
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

        /// <summary>
        /// Gets a date and/or time from the user
        /// </summary>
        /// <param name="prompt">The prompt shown to the user</param>
        /// <returns>The time the user entered</returns>
        static DateTime GetDateTime(string prompt)
        {
            string userString;
            DateTime output;
            do
            {
                Console.Write(prompt);
                userString = Console.ReadLine();
            }
            while (!DateTime.TryParse(userString, out output));
            return output;
        }

        /// <summary>
        /// Gets a date and/or time from the user
        /// </summary>
        /// <param name="prompt">The prompt shown to the user</param>
        /// <returns>The time the user entered</returns>
        public static DateTime GetFutureDateTime(string prompt)
        {
            DateTime output;
            do
            {
                output = GetDateTime(prompt);
            }
            while (output.Subtract(DateTime.Now).Ticks <= 0);
            return output;
        }

        /// <summary>
        /// repeatedly Prompts the user for an int and only returns once they have
        /// entered a valid int in the given range
        /// </summary>
        /// <param name="prompt">The prompt shown to the user</param>
        /// <param name="min">The smallest valid int</param>
        /// <param name="max">The largest valid int</param>
        /// <returns>The first valid int entered by the user</returns>
        public static double GetDoubleInRange(string prompt, double min, double max)
        {
            double output;
            string input;
            do
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (!double.TryParse(input, out output) || output < min || output > max);

            return output;
        }

        public static void DrawHorse(int x, int y, ConsoleColor color) 
        {
            Console.SetCursorPosition(x, y);
            WriteWithColor("   _____,,;;;`;", color);
            Console.SetCursorPosition(x, y+1);
            WriteWithColor(",~(  )  , )~~\\|", color);
            Console.SetCursorPosition(x, y+2);
            WriteWithColor("' / / --`--,   ", color);
            Console.SetCursorPosition(x, y+3);
            WriteWithColor(" /  \\    | '   ", color);
        }

        public static void DrawShopKeep(List<Item> items, int capacity) 
        {
            WriteWithColor("   _______\n", ConsoleColor.Blue);
            WriteWithColor("  / / | \\ \\\n", ConsoleColor.Blue);
            WriteWithColor("  ^^^^|^^^^\n", ConsoleColor.Blue);
            WriteWithColor("      |\n", ConsoleColor.Blue);
            WriteWithColor("  ()()|\n", ConsoleColor.Blue);
            WriteWithColor("  (*-*)\n", ConsoleColor.Blue);
            WriteWithColor("  (v v)\n", ConsoleColor.Blue);
            int row = Console.CursorTop - 4;
            Console.SetCursorPosition(8, row);
            WriteWithColor(" ", ConsoleColor.Blue);
            for (int i = 0; i < items.Count; i++) 
            {
                WriteWithColor($" {items[i].DisplayChar} ", items[i].DisplayColor);
            }
            Console.SetCursorPosition(8, row+1);
            WriteWithColor("▄", ConsoleColor.Blue);
            for (int i = 0; i < capacity; i++)
            {
                WriteWithColor($"▄█▄", ConsoleColor.Blue);
            }
            WriteWithColor("▄", ConsoleColor.Blue);
            Console.SetCursorPosition(8, row+2);
            WriteWithColor("\\", ConsoleColor.Blue);
            for (int i = 0; i < capacity; i++)
            {
                WriteWithColor($"___", ConsoleColor.Blue);
            }
            WriteWithColor("/", ConsoleColor.Blue);
            DrawHorse(11 + (capacity * 3), row, ConsoleColor.Blue);
            Console.SetCursorPosition(8, row + 3);
            WriteWithColor("0", ConsoleColor.Blue);
            for (int i = 0; i < capacity; i++)
            {
                WriteWithColor($"---", ConsoleColor.Blue);
            }
            WriteWithColor("0", ConsoleColor.Blue);
            Console.WriteLine();
            WriteWithColor("============================================\n", ConsoleColor.Blue);
        }
    }
}
