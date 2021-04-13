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

            // 1. Use a loop to find the game in `games` that can be played by the most players.
            // 2. Print the game. (Expected: "Ultimate Werewolf...")
        }
    }
}

