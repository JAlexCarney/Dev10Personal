using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal.Entities
{
    public class Hero : IEntity, ICharacter
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; }
        public char DisplayChar { get; set; }
        public ConsoleColor Color { get; set; }
        public GameBoard ParentBoard { get; set; }
        public int Health { get; set; }
        public int HealthMax { get; set; }
        public int Power { get; set; }

        public Hero(GameBoard parent, int x, int y) 
        {
            ParentBoard = parent;
            X = x;
            Y = y;
            DisplayChar = '@';
            IsActive = true;
            HealthMax = 30;
            Health = HealthMax;
            Power = 1;
            Color = ConsoleColor.DarkYellow;
        }

        public void Attack(ICharacter attacking)
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Spawn()
        {
            throw new NotImplementedException();
        }
    }
}
