using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class Human : Player
    {
        public int Number { get; set; }
        public Choice GetChoice() 
        {
            Console.WriteLine($"Make a choice Player {Number}!");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors\n");
            return (Choice)Program.GetIntInRange("Enter Choice: ", 1, 3);
        }
    }
}
