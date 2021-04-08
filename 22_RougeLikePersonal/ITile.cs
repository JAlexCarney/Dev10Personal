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
        public void Draw()
        {
            Console.BackgroundColor = Color;
            if (EntityOnTile != null && EntityOnTile.IsActive)
            {
                Console.ForegroundColor = EntityOnTile.Color;
                Console.Write(EntityOnTile.DisplayChar);
            }
            else
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
