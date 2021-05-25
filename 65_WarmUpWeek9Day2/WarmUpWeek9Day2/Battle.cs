using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A = 65, Z = 90 -> 27 - 52
//a = 97, z = 122 -> 1 - 26

namespace WarmUpWeek9Day2
{
    public class Battle
    {
        public static string Combat(string one, string two)
        {
            bool isOneAlive = true;
            bool isTwoAlive = true;
            while (isOneAlive && isTwoAlive)
            {
                var result = Fight(one[0], two[0]);

                if (result[0] == '=')
                {
                    one = one.Substring(1);
                    two = two.Substring(1);
                }
                else if (result[1] == '1')
                {
                    two = two.Substring(1);
                    one = result[0] + one.Substring(1);
                }
                else
                {
                    one = two.Substring(1);
                    two = result[0] + two.Substring(1);
                }

                if (string.IsNullOrEmpty(one))
                {
                    isOneAlive = false;
                }
                if (string.IsNullOrEmpty(two))
                {
                    isTwoAlive = false;
                }
            }
            if (isOneAlive)
            {
                return $"Winner: One({one})";
            }
            if (isTwoAlive)
            {
                return $"Winner: Two({two})";
            }
            return "Draw";
        }

        public static char[] Fight(char c1, char c2)
        {
            int h1 = CharToHealth(c1);
            int h2 = CharToHealth(c2);
            if (h1 == h2)
            {
                return new char[] { '=', '=' };
            }
            if (h1 > h2)
            {
                return new char[] { HealthToChar((int)Math.Round(h1 / 3.0)), '1' };
            }
            if (h2 > h1)
            {
                return new char[] { HealthToChar((int)Math.Round(h2 / 3.0)), '2' };
            }
            throw new Exception("something bad happened");
        }

        public static int CharToHealth(char input)
        {
            if (char.IsLower(input))
            {
                return (int)(input) - 96;
            }
            return (int)(input) - 38;
        }

        public static char HealthToChar(int health)
        {
            if (1 <= health && health <= 26)
            {
                return (char)(health + 96);
            }
            return (char)(health + 38);
        }

        public class Result
        {
            public char Health { get; set; }
            public int Winner { get; set; }
        }
    }
}
