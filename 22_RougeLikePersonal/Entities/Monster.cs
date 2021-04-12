using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal.Entities
{
    class Monster : IEntity, ICharacter
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

        private readonly Random _rng = new Random();

        public Monster(GameBoard parent, int x, int y)
        {
            ParentBoard = parent;
            X = x;
            Y = y;
            DisplayChar = 'M';
            IsActive = true;
            HealthMax = 30;
            Health = HealthMax;
            Power = 1;
            Color = ConsoleColor.DarkRed;
        }

        public void Update()
        {
            int direction = _rng.Next(8);

            switch (direction) 
            {
                case 0:
                    ((IEntity)this).Move(Directions.UP);
                    break;
                case 1:
                    ((IEntity)this).Move(Directions.DOWN);
                    break;
                case 2:
                    ((IEntity)this).Move(Directions.LEFT);
                    break;
                case 3:
                    ((IEntity)this).Move(Directions.RIGHT);
                    break;
            }
        }

        public void Attack(ICharacter attacking)
        {
            CombatLog.LogCombat($"{DisplayChar} attacked {attacking.DisplayChar} for {Power} damage!");
            attacking.Health -= Power;
        }

        public void Die()
        {
            CombatLog.LogCombat($"{DisplayChar} died!");

            ParentBoard.Data[X, Y].EntityOnTile = null;
        }

        public void MovedIntoBy(IEntity other)
        {
            if (other is Hero hero)
            {
                GameController.Battle(hero, this);
            }
        }

        public void Spawn()
        {
            throw new NotImplementedException();
        }
    }
}
