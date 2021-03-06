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

        public int Money { get; set; }

        public Hero(GameBoard parent, int x, int y) 
        {
            ParentBoard = parent;
            X = x;
            Y = y;
            Money = 0;
            DisplayChar = '☺';
            IsActive = true;
            HealthMax = 30;
            Health = HealthMax;
            Power = 2;
            Color = ConsoleColor.DarkYellow;
        }

        public void Update() 
        {
            // Do Nothing
        }

        public void MovedIntoBy(IEntity other) 
        {
            if (other is Monster monster) 
            {
                GameController.Battle(monster, this);
            }
        }

        public void Attack(ICharacter attacking)
        {
            CombatLog.LogCombat($"{DisplayChar} attacked {attacking.DisplayChar} for {Power} damage!");
            attacking.Health -= Power;
        }

        public void Die()
        {
            // rip Game Over
        }

        public void Spawn()
        {
            throw new NotImplementedException();
        }
    }
}
