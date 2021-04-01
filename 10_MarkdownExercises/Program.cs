using System;

namespace _10_MarkdownExercises
{
    public class Program
    {
        static void Main(string[] args) 
        {
            string toWrite = "";
            for (int i = 0; i < 25; i++) 
            {
                for (int j = 0; j < 50; j++) 
                {
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        toWrite += " ";
                    }
                    else
                    {
                        toWrite += "0";
                    }
                    
                }
                toWrite += "\n";
            }
            WriteRainbow(toWrite);
        }

        public static void WriteRainbow(string phrase) 
        {
            for (int i = 0; i < phrase.Length; i++) 
            {
                if (i % 7 == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (i % 7 == 1)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (i % 7 == 2)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (i % 7 == 3)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (i % 7 == 4)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (i % 7 == 5)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (i % 7 == 6)
                    Console.ForegroundColor = ConsoleColor.Magenta;

                Console.Write(phrase[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
