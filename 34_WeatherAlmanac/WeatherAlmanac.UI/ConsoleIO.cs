using System;
using System.Collections.Generic;
using System.Text;
using WeatherAlmanac.Core;

namespace WeatherAlmanac.UI
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

        public static DateRecord GetDateRecord() 
        {
            var dateRecord = new DateRecord();
            dateRecord.Date = GetDateTime("Enter the Date : ");
            dateRecord.HighTemp = GetDecimalInRange("Enter the High Temp : ", -100M, 200M);
            dateRecord.LowTemp = GetDecimalInRange("Enter the Low Temp : ", -100M, 200M);
            dateRecord.Humidity = GetDecimalInRange("Enter the Humidity : ", 0M, 100M);
            dateRecord.Description = GetString("Enter a discription : ");
            return dateRecord;
        }

        /// <summary>
        /// Waits for user to enter any key
        /// </summary>
        public static void PromptContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void DisplayDateRecord(DateRecord record) 
        {
            Console.WriteLine();
            WriteWithColor("Date : ", ConsoleColor.Yellow);
            WriteWithColor($"{record.Date}\n", ConsoleColor.Yellow);
            WriteWithColor("   High Temp   : ", ConsoleColor.Yellow);
            WriteWithColor($"{record.HighTemp}\n", ConsoleColor.Yellow);
            WriteWithColor("   Low Temp    : ", ConsoleColor.Yellow);
            WriteWithColor($"{record.LowTemp}\n", ConsoleColor.DarkYellow);
            WriteWithColor("   Humidity    : ", ConsoleColor.Yellow);
            WriteWithColor($"{record.Humidity}\n", ConsoleColor.DarkYellow);
            WriteWithColor("   Discription : ", ConsoleColor.Yellow);
            WriteWithColor($"{record.Description}\n", ConsoleColor.DarkYellow);
        }

        public static void DisplaySuccess(string prompt) 
        {
            WriteWithColor(prompt, ConsoleColor.Green);
            Console.WriteLine();
        }

        public static void DisplayFailure(string prompt) 
        {
            WriteWithColor(prompt, ConsoleColor.Red);
            Console.WriteLine();
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
        /// Display a numbered list of options
        /// </summary>
        /// <param name="options">any number of options to display</param>
        public static void DisplayMenuOptions(params string[] options) 
        {
            for (int i = 0; i < options.Length; i++)
            {
                WriteWithColor($"{i+1}. {options[i]}\n", ConsoleColor.DarkYellow);
            }
            Console.WriteLine();
        }

        public static void DisplayHeader(string title) 
        {
            Console.Clear();
            WriteWithColor(title, ConsoleColor.Yellow);
            Console.WriteLine();
            WriteWithColor("===============================\n", ConsoleColor.DarkYellow);
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
        public static DateTime GetDateTime(string prompt)
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
        /// repeatedly Prompts the user for an decimal and only returns once they have
        /// entered a valid int in the given range
        /// </summary>
        /// <param name="prompt">The prompt shown to the user</param>
        /// <param name="min">The smallest valid decimal</param>
        /// <param name="max">The largest valid decimal</param>
        /// <returns>The first valid int entered by the user</returns>
        public static decimal GetDecimalInRange(string prompt, decimal min, decimal max)
        {
            decimal output;
            string input;
            do
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (!decimal.TryParse(input, out output) || output < min || output > max);

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
    }
}
