using ListExercises.Game;
using System;
using System.Collections.Generic;

namespace ListExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BoardGame> games = GameRepository.GetAll();

            // 1. Swap the 2nd game with the 4th and the 3rd with the 7th.
            // 2. Print `games` and confirm their order.
        }
    }
}
