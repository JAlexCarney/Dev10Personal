using System;

namespace _04_15WarmUp
{
    class Program
    {
        static string[] keys = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        static void Main(string[] args)
        {
            string userIn = PromptUser("Please enter a set of keys: ");
            string shifted = UpAThirdMany(userIn);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(shifted);
            Console.ResetColor();
        }

        /// <summary>
        /// Converts a single string key into the key up a third
        /// </summary>
        /// <param name="input">The key string to shift</param>
        /// <returns>The shifted key string</returns>
        static string UpAThird(string input)
        {
            int index = -1;
            for (int i = 0; i < keys.Length; i++)
            {
                if (input.Equals(keys[i]))
                {
                    index = i;
                    break;
                }
                else if (i == keys.Length - 1 && index == -1) 
                {
                    return "";
                }
            }
            return keys[(index + 4) % keys.Length];
        }

        static string PromptUser(string prompt)
        {
            string output;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                output = Console.ReadLine().ToUpper().Trim();
                Console.ForegroundColor = ConsoleColor.White;
            } while (string.IsNullOrEmpty(output));
            return output;
        }

        static string UpAThirdMany(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length && input[i + 1] == '#') //charcter has a sharp
                {
                    output += UpAThird($"{input[i]}#");
                    i++;
                }
                else
                {
                    output += UpAThird($"{input[i]}");
                }
            }
            return output;
        }
    }
}
