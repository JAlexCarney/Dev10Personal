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

            // 1. Instantiate a new List<BoardGame> and call it `economicGames`.
            // 2. Loop over `games`. Add each game with the "Economic" category to `economicGames`.
            // 3. Print `economicGames`.
        }
    }
}
