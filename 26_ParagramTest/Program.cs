using System;

namespace ParagramTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(IsPanagram("aBcDefghijklmnopqrstuvwxyz"));
            Console.WriteLine(IsPanagram("the quick brown fox jumps over the lazy dog"));
            Console.WriteLine(IsPanagram("Hello World!"));
        }

        static bool IsPanagram(string toCheck)
        {
            bool[] letters = new bool[26];
            toCheck = toCheck.ToUpper();
            foreach (char c in toCheck)
            {
                if (c > 64 && c < 91)
                {
                    letters[c - 65] = true;
                }
            }
            for (int i = 0; i < letters.Length; i++)
            {
                if (!letters[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
