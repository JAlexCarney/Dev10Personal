using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal.Tiles
{
    public class Floor : ITile
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public ConsoleColor Color { get; set; }
        public IEntity EntityOnTile { get; set; }

        public Floor(int col, int row) 
        {
            Col = col;
            Row = row;
            Color = ConsoleColor.Black;
            EntityOnTile = null;
        }
    }
}
