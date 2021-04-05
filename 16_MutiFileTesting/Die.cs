using System;
using System.Collections.Generic;
using System.Text;

namespace MutiFileTesting
{
    class Die
    {
        private Random _rng = new Random();
        private const int Sides = 6;
        public int[] Rolls { get; private set; } = new int[11];

        public int Roll(bool isVerbose = false) 
        {
            // perform 2 rolls
            int die1 = _rng.Next(1, Sides + 1);
            int die2 = _rng.Next(1, Sides + 1);

            // add the results
            int roll = die1 + die2;

            // track every roll in a histogram
            AddRollResult(roll);

            // give user feedback if requested
            if (isVerbose) 
            {
                Console.WriteLine($"You rolled a {die1} and a {die2} totaling in {roll}.");
            }
            
            // give user back their roll
            return roll;
        }

        private void AddRollResult(int roll) 
        {
            Rolls[roll - 2]++;
        }

        public void ShowPastRolls() 
        {
            for (int i = 0; i < Rolls.Length; i++) 
            {
                Console.Write($"{i+2,5:0.} : ");
                for (int j = 0; j < Rolls[i]; j++) 
                {
                    Console.Write("#");
                }
                Console.WriteLine("");
            }
        }
    }
}
