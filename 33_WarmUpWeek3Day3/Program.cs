using System;

namespace WarmUpWeek3Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCans = 0;
            bool check = false;
            decimal pricePerCan = 0.0M;
            do
            {
                Console.WriteLine("Please enter the number of cans you would like to purchase: ");
                check = int.TryParse(Console.ReadLine(), out numCans);
            } while (!check);
            do
            {
                Console.WriteLine("Please enter the price of one can: ");
                check = decimal.TryParse(Console.ReadLine(), out pricePerCan);
            } while (!check);
            decimal result = CanReturnValue(numCans, pricePerCan);
            Console.Write("You're payment is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{result:C}");
            Console.ResetColor();
            Console.WriteLine("!");
        }

        public static decimal CanReturnValue(int numCans)
        {
            return CanReturnValue(numCans, 0.5M);
        }

        public static decimal CanReturnValue(int numCans, decimal price)
        {
            decimal result = ((decimal)numCans) * price;

            // remove every third can
            result -= Math.Floor(((decimal)numCans) / 3M) * price;

            return result;
        }
    }

    
}
