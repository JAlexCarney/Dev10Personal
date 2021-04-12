using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal.Entities
{
    public class Treasure : IEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; }
        public char DisplayChar { get; set; }
        public ConsoleColor Color { get; set; }
        public GameBoard ParentBoard { get; set; }
        private readonly int _value;

        public void MovedIntoBy(IEntity other) 
        {
            if (other is Entities.Hero hero) 
            {
                hero.Money += _value;

                ParentBoard.Data[X, Y].EntityOnTile = hero;
                ParentBoard.Data[hero.X, hero.Y].EntityOnTile = null;
                hero.X = X;
                hero.Y = Y;
            }
        }

        public void Update()
        {
            // Do Nothing
        }

        public Treasure(GameBoard parent, int x, int y) 
        {
            ParentBoard = parent;
            X = x;
            Y = y;
            DisplayChar = '$';
            IsActive = true;
            Color = ConsoleColor.Green;
            Random rng = new Random();
            _value = rng.Next(10, 101);
        }
    }
}
