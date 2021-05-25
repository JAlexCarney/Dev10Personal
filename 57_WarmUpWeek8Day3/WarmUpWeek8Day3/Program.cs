using System;
using System.Drawing;
using System.Linq;

namespace WarmUpWeek8Day3
{
    class Program
    {
        static ConsoleIO io = new ConsoleIO();

        static void Main(string[] args)
        {
            io.PrintLineYellow("Wellcome To Cube Calculator");
            io.PrintLineYellow("===========================");
            io.PrintLine("");
            int sideLength = io.ReadInt("Enter the side length of your cube: ", 1, 300);
            int invisibleCubes = InvisibleCubes(sideLength);
            io.PrintLine("");
            DrawCube(sideLength);
            io.PrintLine("");
            io.PrintLineGreen($"Your cube contains {invisibleCubes} hidden cubes!");
            
        }

        static int InvisibleCubes(int n) 
        {
            return (n*n*n) - 
                ( 
                    (2 * n * n) +
                    (2 * (n-2) * n) +
                    (2 * (n-2) * (n-2))
                );
        }

        static void DrawCube(int n) 
        {
            string plus = "+";
            int doubled = 2 * n;
            char space = ' ';
            string Space = new string(space, doubled);
            int halved = n / 2;
            string T = new string(space, halved);
            string Line = "\n";
            string or_sign = "/";
            string vertical = "|";
            string a = plus + new string('-', doubled) + plus;
            string result = T + space + a + Line;
            for (int i = 0; i < halved - 1; i++)
            {
                result = result + new string(space, halved - i) + or_sign + Space + or_sign + new string(space, i) + vertical + Line;
            }
            result = result + a + T + vertical;
            for (int i = 1; i < halved; i++) 
            {
                result = result + Line + vertical + Space + vertical + T + (i == halved ? plus : vertical);
            }
            for (int i = halved - 1; i > 0; i--)
            {
                result = result + Line + vertical + Space + vertical + new string(space, i) + or_sign;
            }

            io.PrintLineYellow(result + Line + a);
        }
    }
}
