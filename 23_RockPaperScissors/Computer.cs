using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class Computer : Player
    {
        public int Number { get; set; }
        private Random rng = new Random();
        public Choice GetChoice() 
        {
            return (Choice)rng.Next(1,4);
        }
    }
}
