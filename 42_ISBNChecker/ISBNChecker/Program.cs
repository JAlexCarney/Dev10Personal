using System;
using System.Linq;

namespace ISBNChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the ISBN that you would like to check:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            int[] isbn = StringToIntArray(Console.ReadLine());
            bool isValid = CheckISBN10(isbn);
            if (!isValid) 
            {
                isValid = CheckISBN13(isbn);
            }
            if (isValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("That is a valid ISBN!");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That is NOT a valid ISBN!");
            }
            Console.ResetColor();
            /*
            int[] nums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            var filtered = nums.Where(TestPredicate);

            Console.WriteLine($"Found: {filtered.LastOrDefault()}");
            Console.WriteLine($"Found: {filtered.FirstOrDefault()}");
            Console.WriteLine($"Any equal to 2 : {filtered.Any(n => n == 2)}");
            Console.WriteLine($"All greater than 5 : {filtered.All(n => n > 5)}");

            var filtered2 = nums.Where(TestPredicate).ToList();

            Console.WriteLine($"Found: {filtered2.LastOrDefault()}");
            Console.WriteLine($"Found: {filtered2.FirstOrDefault()}");
            Console.WriteLine($"Any equal to 2 : {filtered2.Any(n => n == 2)}");
            Console.WriteLine($"All greater than 5 : {filtered2.All(n => n > 5)}");
            */
        }

        static bool TestPredicate(int test) 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Checking: {test}");
            Console.ResetColor();
            return test % 2 == 0;
        }

        static int[] StringToIntArray(string input) 
        {
            int[] output = new int[input.Length];
            for (int i = 0; i < input.Length; i++) 
            {
                output[i] = int.Parse(input[i].ToString());
            }
            return output;
        }

        static bool CheckISBN10(int[] digits) 
        {
            if (digits.Length != 10) 
            {
                return false;
            }

            int total = 0;
            for(int i = 0; i < digits.Length; i++)
            {
                total += (digits[i]  *  (digits.Length-i));
            }

            return total % 11 == 0;
        }

        static bool CheckISBN13(int[] digits) 
        {
            if (digits.Length != 13) 
            {
                return false;
            }

            int total = 0;
            for(int i = 0; i < digits.Length; i++)
            {
                if (i % 2 == 0)
                {
                    total += digits[i];
                }
                else 
                {
                    total += digits[i] * 3;
                }
            }

            return total % 10 == 0;
        }
    }
}
