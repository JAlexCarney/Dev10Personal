using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    public interface IEntity
    {
        int X { get; set; }
        int Y { get; set; }
        bool IsActive { get; set; }
        char DisplayChar { get; set; }
        ConsoleColor Color { get; set; }
        GameBoard ParentBoard { get; set; }

        public void MovedIntoBy(IEntity other);

        public void Update();

        public bool Move(Directions direction) 
        {
            int xToGo = X;
            int yToGo = Y;

            switch (direction) 
            {
                case Directions.UP:
                    yToGo--;
                    break;
                case Directions.DOWN:
                    yToGo++;
                    break;
                case Directions.LEFT:
                    xToGo--;
                    break;
                case Directions.RIGHT:
                    xToGo++;
                    break;
            }

            if (ParentBoard.IsOccupied(xToGo, yToGo)) 
            {
                ParentBoard.Data[xToGo, yToGo].EntityOnTile.MovedIntoBy(this);
                return false;
            }

            // valid move
            ParentBoard.Place(this, xToGo, yToGo);
            ParentBoard.Remove(X, Y);
            X = xToGo;
            Y = yToGo;
            return true;
        }
    }
}
