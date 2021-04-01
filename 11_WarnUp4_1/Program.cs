using System;

namespace _11_WarnUp4_1
{
    class Program
    {
        public static void WriteWithRandomColor(string toWrite) 
        {
            // get a random double
            Random random = new Random();
            double randomDouble = random.NextDouble();
            
            // select random color from random double
            if (randomDouble < 0.25)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (randomDouble < 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (randomDouble < 0.75)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            // display string with color
            Console.Write(toWrite);

            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void Main(string[] args)
        {
            // create a rectangle
            int width = 20;
            int height = 10;

            // draw the rectangle to screen
            for (int i = 0; i < height; i++) 
            {
                for (int j = 0; j < width; j++) 
                {
                    WriteWithRandomColor("#");
                }
                Console.Write("\n");
            }

            // end
        }
    }
}
