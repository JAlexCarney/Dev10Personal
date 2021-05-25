using System;

namespace WarmUpMay20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome To Code Breaker");
            Console.WriteLine("========================");
            DrawKeyPad();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\\/ Encodes into \\/");
            DrawEncodedKeyPad();
            Console.ResetColor();

            while (true)
            {
                Console.Write("Enter a phone number to decode: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string phoneNumber = Console.ReadLine();
                string decoded = Decoder.Decode(phoneNumber);
                if (decoded != "")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Decoded phone number: {decoded}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Failed to decode {phoneNumber}!");
                }
                Console.ResetColor();
            }
        }

        static void DrawKeyPad()
        {
            string KeypadString = "\n┌───┬───┬───┐\n│ 1 │ 2 │ 3 │\n├───┼───┼───┤\n│ 4 │ 5 │ 6 │\n├───┼───┼───┤\n│ 7 │ 8 │ 9 │\n└───┼───┼───┘\n    │ 0 │\n    └───┘";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(KeypadString);
            Console.ResetColor();
        }

        static void DrawEncodedKeyPad()
        {
            string KeypadString = "┌───┬───┬───┐\n│ 9 │ 8 │ 7 │\n├───┼───┼───┤\n│ 6 │ 0 │ 4 │\n├───┼───┼───┤\n│ 3 │ 2 │ 1 │\n└───┼───┼───┘\n    │ 5 │\n    └───┘\n";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(KeypadString);
            Console.ResetColor();
        }
    }
}
