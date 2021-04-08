using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public enum Choice
    {
        ROCK = 1,
        PAPER = 2,
        SCISSORS = 3
    }

    public interface Player
    {
        public int Number { get; set; }
        public Choice GetChoice();
    }
}
