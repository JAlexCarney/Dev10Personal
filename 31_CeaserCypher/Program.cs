using System;
using System.Collections.Generic;

namespace CeaserCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            string english = "abcdefghijklmnopqrstuvwxyz";

            Console.WriteLine("What would you like to encrypt?");
            string message = Console.ReadLine();
            Console.WriteLine("What should the shift be?");
            int shift = int.Parse(Console.ReadLine());

            string encrypted = CeaserCypher(english, shift, message);
            Console.WriteLine("Your encrypted message is :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(encrypted);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static string CeaserCypher(string alphabet, int shift, string message) 
        {
            Dictionary<char, char> cypher = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++) 
            {
                int cypherIndex = (((i + shift) % alphabet.Length) + alphabet.Length) % alphabet.Length;
                cypher.Add(alphabet[i], alphabet[cypherIndex]); 
            }

            string encryptedMessage = "";

            string loweredMessage = message.ToLower();

            for (int i = 0; i < message.Length; i++) 
            {
                if (alphabet.Contains(loweredMessage[i].ToString()))
                {
                    // is lower case
                    if (loweredMessage[i] == message[i])
                    {
                        encryptedMessage += cypher[loweredMessage[i]];
                    }
                    else 
                    {
                        encryptedMessage += cypher[loweredMessage[i]].ToString().ToUpper()[0];
                    }
                }
                else 
                {
                    encryptedMessage += message[i];
                }
            }

            return encryptedMessage;
        }
    }
}
