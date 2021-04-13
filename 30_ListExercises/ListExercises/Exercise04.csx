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

            // 1. Instantiate a new List<BoardGame>.
            // 2. Add three BoardGames to the new list.
            // 3. Print the new list.
            // 4. Add items in the new list to `games` with the `AddRange` method.
            // 5. Print `games`.
        }
    }
}
