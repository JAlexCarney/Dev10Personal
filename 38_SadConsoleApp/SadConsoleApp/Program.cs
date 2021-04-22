using System;
using PasswordGenerator;
using ColorConsole;

namespace SadConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Password password = new Password();
            Console.WriteLine(password.Next());
            ConsoleWriter writer = new ConsoleWriter();
            writer.SetForeGroundColor(ConsoleColor.Red);
            writer.Write(password.Next());
            writer.SetForeGroundColor(ConsoleColor.White);
        }
    }
}
