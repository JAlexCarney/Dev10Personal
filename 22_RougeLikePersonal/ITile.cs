using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    public interface ITile
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public ConsoleColor Color { get; set; }
        public IEntity EntityOnTile { get; set; }
        public void Draw();
    }
}
