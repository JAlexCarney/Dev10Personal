using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class AlwaysChooses : Player 
    {
        private Choice _choice;
        public int Number { get; set; }
        public AlwaysChooses(Choice choice) 
        {
            _choice = choice;
        }

        public Choice GetChoice() 
        {
            return _choice;
        }
    }
}
