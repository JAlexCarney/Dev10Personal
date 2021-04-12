using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    class GameController
    {
        private readonly GameBoard _board;
        private readonly Entities.Hero _hero;

        public GameController() 
        {
            _board = new GameBoard(30, 15);
            _hero = new Entities.Hero(_board, 1, 1);
            _board.Place(_hero,1,1);
            _board.Draw();
        }

        public void Run() 
        {
            while (true) 
            {
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;

                _board.Draw();
                PrintStats();
                DisplayCombatLog();

                char c = Console.ReadKey().KeyChar;
                Console.CursorLeft = 0;
                Console.Write(" ");

                switch (c) 
                {
                    case 'w':
                        ((IEntity)_hero).Move(Directions.UP);
                        break;
                    case 'a':
                        ((IEntity)_hero).Move(Directions.LEFT);
                        break;
                    case 's':
                        ((IEntity)_hero).Move(Directions.DOWN);
                        break;
                    case 'd':
                        ((IEntity)_hero).Move(Directions.RIGHT);
                        break;
                }

                _board.UpdateAll();
            }
        }

        public void PrintStats() 
        {
            Console.SetCursorPosition(_board.Data.GetLength(0) + 2, 0);
            Console.WriteLine($"--- Statistics ---");
            Console.SetCursorPosition(_board.Data.GetLength(0) + 2, 1);
            Console.WriteLine($"Health : {_hero.Health}/{_hero.HealthMax}");
            Console.SetCursorPosition(_board.Data.GetLength(0)+2, 2);
            Console.WriteLine($"Money  : {_hero.Money:C}");
        }

        public void DisplayCombatLog() 
        {
            Console.SetCursorPosition(_board.Data.GetLength(0) + 2, 5);
            Console.WriteLine($"--- Combat Log ---");
            int linesToWrite = CombatLog.Log.Count > 5 ? 5 : CombatLog.Log.Count;
            for (int i = 0; i < linesToWrite; i++) 
            {
                Console.SetCursorPosition(_board.Data.GetLength(0) + 2, 6+i);
                Console.Write(CombatLog.Log[i]);
            }
        }

        /// <summary>
        /// Loops through attacks unitil a winner is decided
        /// </summary>
        /// <param name="one">The first Character fighting</param>
        /// <param name="two">The second Character fighting</param>
        /// <returns>true if one wins and false if two wins</returns>
        public static bool Battle(ICharacter one, ICharacter two) 
        {
            bool isOnesTurn = true;
            while (one.Health > 0 && two.Health > 0) 
            {
                if (isOnesTurn)
                {
                    one.Attack(two);
                }
                else 
                {
                    two.Attack(one);
                }
                isOnesTurn = !isOnesTurn;
            }

            if (two.Health <= 0)
            {
                two.Die();
                return true;
            }
            one.Die();
            return false;
        }
    }
}
