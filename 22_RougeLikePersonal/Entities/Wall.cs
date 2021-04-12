using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal.Entities
{
    public class Wall : IEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; }
        public char DisplayChar { get; set; }
        public ConsoleColor Color { get; set; }
        public GameBoard ParentBoard { get; set; }

        public void Update()
        {
            // Do Nothing
        }

        public void MovedIntoBy(IEntity other) 
        {
            //Console.Beep();
        }

        public Wall(GameBoard parent, int x, int y) 
        {
            ParentBoard = parent;
            X = x;
            Y = y;
            DisplayChar = '█';
            IsActive = true;
            Color = ConsoleColor.DarkGray;
        }
    }
}
