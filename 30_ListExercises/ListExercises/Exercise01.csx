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

			// 1. Grab the 6th game from `games` (index 5).
			// 2. Print it to the console. (Expected: "7 Wonders")
		}
	}
}
