using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Engine
{
    class GameLogic
    {
        public GamePiece[,] board { get; private set; }
        private bool IsPlayerOnesTurn;

        public GameLogic() 
        {
            IsPlayerOnesTurn = true;
            InitializeBoard();
        }

        private void InitializeBoard() 
        {
            board = new GamePiece[7, 6];
            for (int i = 0; i < board.GetLength(0); i++) 
            {
                for (int j = 0; j < board.GetLength(1); j++) 
                {
                    board[i, j] = GamePiece.Empty;
                }
            }
        }

        public void NextTurn(int choice) 
        {

        }
    }
}
