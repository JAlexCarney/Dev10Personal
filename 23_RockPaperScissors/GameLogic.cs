using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public class GameLogic
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        private string[] choices = new string[] { "Rock", "Paper", "Scissors" };


        public GameLogic(Player one, Player two) 
        {
            PlayerOne = one;
            one.Number = 1;
            PlayerTwo = two;
            two.Number = 2;
        }

        public void Shoot() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ROCK!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PAPER!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SCISSORS!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("SHOOT!");
            Console.ForegroundColor = ConsoleColor.White;
            Choice choice1 = PlayerOne.GetChoice();
            Choice choice2 = PlayerTwo.GetChoice();
            Console.WriteLine($"Player 1 Chose {choice1}");
            Console.WriteLine($"Player 2 Chose {choice2}");

            if (choice1 == choice2) 
            {
                Console.WriteLine($"Both players choose {choice1}! That's a DRAW!");
            }
            else if ((choice1 == Choice.ROCK && choice2 == Choice.SCISSORS)
                || (choice1 == Choice.PAPER && choice2 == Choice.ROCK)
                || (choice1 == Choice.SCISSORS && choice2 == Choice.PAPER))
            {
                // Player one wins
                DisplayWinner(PlayerOne);
            }
            else
            {
                // Player Two wins
                DisplayWinner(PlayerTwo);
            }
        }

        public void DisplayWinner(Player player) 
        {
            Console.Write("The winner is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Player {player.Number} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("they are a ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (player is Human)
            {
                Console.Write("Human");
            }
            else if (player is Computer)
            {
                Console.Write("Computer");
            }
            else if (player is AlwaysChooses) 
            {
                Console.Write("Dumb Computer");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("!\n");
        }
    }
}
