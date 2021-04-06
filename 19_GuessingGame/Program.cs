using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO io = new ConsoleIO();

            io.StartGame();

            while (!io.PromptGuess()) { }
        }
    }
}
