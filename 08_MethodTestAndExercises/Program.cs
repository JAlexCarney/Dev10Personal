using System;
using System.Text;

namespace _08_MethodTestAndExercises
{
    class Program
    {
        public static void WriteRainbow(string s) 
        {
            // create a RNG
            Random r = new Random();
            // loop through each char of s
            foreach (char c in s) 
            {
                // pick a random number from 0 to 7
                float n = r.Next(7);
                
                // use number to associate to color in ROYGBIV
                if (n < 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (n < 2) 
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (n < 3)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (n < 4)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (n < 5)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (n < 6)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (n < 7)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(c);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void Main(string[] args)
        {
            WriteRainbow("Hello, World!\n");
        }
    }
}
