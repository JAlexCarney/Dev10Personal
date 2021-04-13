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

            // 1. Loop over `games` and remove any game that can be played by one person.
            // 2. Print `games` and confirm single-player games are removed.
        }
    }
}
