using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame
{
    class ConsoleIO
    {
        private GameLogic _game = new GameLogic();

        public void StartGame() 
        {
            Console.WriteLine("What should the minimum number be?");
            _game.Min = int.Parse(Console.ReadLine());
            Console.WriteLine("What should the maximum number be?");
            _game.Max = int.Parse(Console.ReadLine());
            _game.GenerateAnswer();
        }

        public bool PromptGuess() 
        {
            Console.WriteLine($"Make a guess between {_game.Min} and {_game.Max}.");
            string result = _game.Guess(int.Parse(Console.ReadLine()));
            bool isWin = false;
            switch (result) 
            {
                case "Win":
                    Console.WriteLine("YEAH YOU GOT IT!");
                    isWin = true;
                    break;
                case "ToHigh":
                    Console.WriteLine("Nope, That's too high!");
                    break;
                case "ToLow":
                    Console.WriteLine("Nope, That's too low!");
                    break;
            }
            return isWin;
        }
    }
}
