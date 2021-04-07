using System;

namespace RougeLikePersonal
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard(30, 15);
            board.Draw();
        }
    }
}
