using System;
using System.IO;

namespace CountingFromAFile
{
    class Program
    {
        private static ConsoleIO io = new ConsoleIO();

        static void Main(string[] args)
        {
            io.PrintLineYellow("Welcome To Number Counter");
            io.PrintLineYellow("==========================");

            io.PrintLine("");
            decimal? sum = SumOfFile();
            if (sum.HasValue) 
            {
                io.PrintLineGreen($"The sum is {sum}");
            }
        }

        public static decimal? SumOfFile()
        {
            string[] numberStrings;

            try
            {
                var text = File.ReadAllText("data.csv");
                numberStrings = text.Split(new char[] { ',', '\n' });
            }
            catch 
            {
                io.PrintLineRed("Failed to read from file!");
                return null;
            }
            decimal sum = 0;

            for(int i = 0; i < numberStrings.Length; i++)
            {
                decimal num;
                if (decimal.TryParse(numberStrings[i], out num))
                {
                    sum += num;
                }
                else 
                {
                    io.PrintLineRed($"Encountered Invalid Data: \"{numberStrings[i]}\"");
                }
            }

            return sum;
        }
    }
}
