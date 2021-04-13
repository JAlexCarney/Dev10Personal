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

            // 1. Remove the the 5th and 10th game from `games`.
            // 2. Print `games`.
        }
    }
}
