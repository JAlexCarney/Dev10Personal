using System;
using System.Linq;

namespace WarmUpWeek8Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 14, 30, 5, 7, 9, 11, 15 };
            int desiredAverage = 30;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Donations so far: ");
            foreach (int number in numbers) 
            {
                Console.Write($"{number:C} ");
            }
            Console.WriteLine($"");
            Console.WriteLine($"Desired avg: {desiredAverage}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The donation needed to meet the desired average is {newAvg(numbers, desiredAverage):C}");
            Console.ResetColor();
        }

        static int newAvg(int[] arr, int navg) 
        {
            return navg * (arr.Length + 1) - arr.Sum();
        }
    }
}
