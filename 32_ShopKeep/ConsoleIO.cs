using System;

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

        public static bool GetYesOrNo(string prompt)
        {
            string input;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.White;
                if (!string.IsNullOrEmpty(input))
                {
                    if (input == "y")
                    {
                        return true;
                    }
                    else if (input == "n")
                    {
                        return false;
                    }
                }
            }
            while (true);
        }

        public static ConsoleColor RandomConsoleColor() 
        {
            var rng = new Random();
            ConsoleColor color;
            double r = rng.NextDouble();
            if (r > 5.0/6.0)
            {
                color = ConsoleColor.Red;
            }
            else if (r > 4.0 / 6.0)
            {
                color = ConsoleColor.Yellow;
            }
            else if (r > 3.0 / 6.0)
            {
                color = ConsoleColor.Green;
            }
            else if (r > 2.0 / 6.0)
            {
                color = ConsoleColor.Blue;
            }
            else if (r > 1.0 / 6.0)
            {
                color = ConsoleColor.Cyan;
            }
            else 
            {
                color = ConsoleColor.Magenta;
            }
            return color;
        }
    }
}
