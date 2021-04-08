using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    class GameController
    {
        private GameBoard _board;
        private Entities.Hero _hero;

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

                _board.Draw();

                char c = Console.ReadKey().KeyChar;

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
            }
        }
    }
}
