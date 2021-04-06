using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class ConnectFourBoard
    {
        private Space[,] _board;

        ConnectFourBoard(int rows = 7, int columns = 6) 
        {
            if (rows < 0) { rows = 7; }
            if (columns < 0) { columns = 7; }
            _board = new Space[rows,columns];
            for (int row = _board.GetLength(0)-1; row >= 0; row--) 
            {
                for (int col = 0; col < _board.GetLength(1); col++) 
                {
                    _board[row, col] = new Space();
                }
            }
        }

        public void DrawBoard() 
        {
            for (int row = _board.GetLength(0) - 1; row >= 0; row--)
            {
                // draw seperating line
                
                for (int col = 0; col < _board.GetLength(1); col++)
                {
                    
                }
            }
        }
    }
}
