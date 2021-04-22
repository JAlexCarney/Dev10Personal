using System;

namespace QueensAttack
{
    class Program
    {
        public struct Piece {
            public int Row;
            public int Col;

            public Piece(int row, int column)
            {
                Row = row;
                Col = column;
            }
        }

        static void Main(string[] args)
        {

            int firstRow = PromptInt("Enter the row of the first queen");
            int firstCol = PromptInt("Enter the column of the first queen");

            int secondRow = PromptInt("Enter the row of the second queen");
            int secondCol = PromptInt("Enter the column of the second queen");

            Piece queen1 = new Piece(firstRow, firstCol);
            Piece queen2 = new Piece(secondRow, secondCol);

            bool attacking = IsQueenAttack(queen1, queen2);
            if (attacking)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Watch out! These queens can attack each other!");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Don't worry, These queens can't attack each other.");
            }
            Console.ResetColor();

        }

        public static bool IsRookAttack(Piece one, Piece two) 
        {
            if (one.Row == two.Row || one.Col == two.Col) 
            {
                return true;
            }
            return false;
        }

        public static bool IsBishopAttack(Piece one, Piece two) 
        {
            if (Math.Abs(one.Row - two.Row) == Math.Abs(one.Col - two.Col)) 
            {
                return true;
            }
            return false;
        }

        public static bool IsQueenAttack(Piece one, Piece two) 
        {
            return IsRookAttack(one, two) || IsBishopAttack(one, two);
        }

        public static bool IsKnightAttack(Piece one, Piece two) 
        {
            if (((Math.Abs(one.Row - two.Row) == 1 && Math.Abs(one.Col - two.Col) == 2) || ((Math.Abs(one.Row - two.Row) == 2 && Math.Abs(one.Col - two.Col) == 1))))
            {
                return true;
            }
            return false;
        }

        public static int PromptInt(string prompt)
        {
            int result;
            bool valid;
            do
            {
                valid = int.TryParse(PromptString(prompt), out result);
            } while (!valid);
            return result;
        }

        public static string PromptString(string prompt)
        {
            string result;
            do
            {
                Console.Write($"{prompt}: ");
                result = Console.ReadLine();
            } while (String.IsNullOrEmpty(result));
            return result;
        }
    }
}
