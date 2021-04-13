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

			// 1. Add three new games to `games` with the `Add` method.
			// 2. Print `games` after each add.
		}
	}
}
