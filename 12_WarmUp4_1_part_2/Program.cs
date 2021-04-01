using System;

namespace _12_WarmUp4_1_part_2
{
    class Program
    {
        public static int PromptForPositiveInt(string prompt) 
        {
            int output = 0;
            string input = "";
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            } 
            while (!int.TryParse(input, out output) || !(output > 0));

            return output;
        }
        
        static void Main(string[] args)
        {
            int size = PromptForPositiveInt("How big of an array would you like?");

            int[] array = new int[size];

            Console.WriteLine(array);
        }
    }
}
