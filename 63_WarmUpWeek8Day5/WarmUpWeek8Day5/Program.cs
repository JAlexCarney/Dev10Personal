using System;

namespace WarmUpWeek8Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Coloured Triangles!");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.ResetColor();
            string row = PromptUser("Please enter a row of colors (R, G, B): ").ToUpper();
            Console.WriteLine();
            if (!ValidateInput(row))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I didn't recognize that input. ");
                Console.ResetColor();
            }
            else
            {
                string[] rows = CalculateAllRows(row);
                PrintRows(rows);
            }
        }

        static string[] CalculateAllRows(string topRow) 
        {
            string[] rows = new string[topRow.Length];
            rows[0] = topRow;
            for (int currentRow = 1; currentRow < rows.Length; currentRow++) 
            {
                rows[currentRow] = CalculateNextRow(rows[currentRow - 1]);
            }
            return rows;
        }

        static char? AddColors(char c1, char c2) 
        {
            if (c1 == c2) return c1;
            if ((c1 == 'G' && c2 == 'B') || (c1 == 'B' && c2 == 'G')) return 'R';
            if ((c1 == 'R' && c2 == 'B') || (c1 == 'B' && c2 == 'R')) return 'G';
            if ((c1 == 'G' && c2 == 'R') || (c1 == 'R' && c2 == 'G')) return 'B';
            return null;
        }

        public static void PrintRows(string[] rows)
        {
            for (int i = 0; i < rows.Length; i++) 
            {
                string rowToPrint = rows[i];
                Console.Write(new string(' ', i));
                foreach (char c in rowToPrint)
                {
                    PrintColoeredChar(c);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        
        static string CalculateNextRow(string row) 
        {
            string result = "";
            for (int i = 0; i < row.Length - 1; i++) 
            {
                result += AddColors(row[i], row[i  +  1]);
            }
            return result;
        }

        static void PrintColoeredChar(char c) 
        {
            switch (c) 
            {
                case 'R':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 'G':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'B':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
            Console.Write(c);
            Console.ResetColor();
        }

        public static string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static bool ValidateInput(string input) 
        {
            var validChars = "RBG";

            foreach(var c in input)
            {
                if (!validChars.Contains(c))
                {
                    return false;
                }                
            }
            return true;
        }
    }
}
