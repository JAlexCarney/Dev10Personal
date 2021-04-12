using System;
using System.Collections.Generic;

namespace FutureDate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> times = new List<DateTime>();

            for (int i = 0; i < 100; i++) 
            {
                times.Add(DateTime.Now);
            }

            for(int i = 0; i < times.Count - 1; i++)
            {
                Console.WriteLine($"{times[i+1].Ticks - times[i].Ticks}");
            }
        }

        static DateTime GetDateTime(string prompt) 
        {
            string userString;
            DateTime output;
            do
            {
                Console.Write(prompt);
                userString = Console.ReadLine();
            }
            while (!DateTime.TryParse(userString, out output));
            return output;
        }
    }
}
