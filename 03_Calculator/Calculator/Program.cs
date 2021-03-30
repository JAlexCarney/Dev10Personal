using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get Room Length From User
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the length of the room: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            decimal length = decimal.Parse(Console.ReadLine());

            // Get Room Width From User
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the width of the room: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            decimal width = decimal.Parse(Console.ReadLine());

            // Get Room Overage From User
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the overage percent: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            decimal overage = decimal.Parse(Console.ReadLine()) / 100M;

            // calculate area
            decimal area = (length * width) * (1 + overage);

            // show user the area
            Console.ForegroundColor = ConsoleColor.Green;
            if (area % 1 == 0)
            {
                Console.WriteLine($"The total area, including overage, is: {area:F0}");
            }
            else if ((area/10M) % 1 == 0)
            {
                Console.WriteLine($"The total area, including overage, is: {area:F1}");
            }
            else
            {
                Console.WriteLine($"The total area, including overage, is: {area}");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
