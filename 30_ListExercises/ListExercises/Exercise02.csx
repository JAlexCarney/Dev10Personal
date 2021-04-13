using ListExercises.Game;
using System;
using System.Collections.Generic;

namespace ListExercises
{
    public class Program
    {
        // 1. Create a method to print all BoardGames in a List<BoardGame>.

        public static void Main(string[] args)
        {
            List<BoardGame> games = GameRepository.GetAll();

            // 2. Print `games` using your "print all" method.
        }
    }
