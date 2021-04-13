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

            // 1. Grab the 8th game in `games`.
            // 2. Remove it by passing its reference to the `Remove` method.
            // 3. Print `games` and confirm it's gone.
        }
    }
}
