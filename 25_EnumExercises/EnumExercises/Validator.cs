using System;

namespace EnumExercises
{
    class Validator
    {
        internal static void Assert(bool condition, string message)
        {
            ConsoleColor current = Console.ForegroundColor;
            if(condition)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[SUCCESS] {message}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERR] {message}");
            }
            Console.ForegroundColor = current;
        }
    }
}
