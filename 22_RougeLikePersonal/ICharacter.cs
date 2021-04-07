using System;
using System.Collections.Generic;
using System.Text;

namespace RougeLikePersonal
{
    public interface ICharacter
    {
        int Health { get; set; }
        int HealthMax { get; set; }
        int Power { get; set; }

        void Attack(ICharacter attacking);
        void Spawn();
        void Die();
    }
}
