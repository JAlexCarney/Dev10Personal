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

            // 1. Shift all games two positions to the left. A game at index 0 "shifts" to the end of the list.
            // Example: A,B,C,D,E -> shifted two positions is -> C,D,E,A,B
            // 2. Print `games` and confirm the new order.
        }
    }
}
