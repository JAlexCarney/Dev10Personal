using System;

namespace _06_TipCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt user for amout paid
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the amount: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            decimal input = decimal.Parse(Console.ReadLine());

            // prompt user for tip percentage
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the tip percentage: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            decimal percentage = decimal.Parse(Console.ReadLine()) / 100M;

            // calculate tip
            decimal tip = input * percentage;

            // display resulting tip
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"For an amount of {input:C} a {percentage:P} tip would be {tip:C} totalling {input + tip:C}.");

            //  Example Output
            //Enter the amount: 100.00
            //Enter the tip percentage: 15
            //For an amount of $100.00 a 15.00 % tip would be $15.00 totalling $115.00.
        }
    }
}
