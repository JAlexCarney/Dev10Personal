using System;
using Spectre.Console;

namespace NuGetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PrintStatistics(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
        }

        public static void PrintStatistics(int[] rolls)
        {
            AnsiConsole.Render(new BarChart()
                .Width(60)
                .Label("[green bold underline]Roll Stastics[/]")
                .CenterLabel()
                .AddItem("2", rolls[0], Color.Yellow)
                .AddItem("3", rolls[1], Color.Yellow)
                .AddItem("4", rolls[2], Color.Yellow)
                .AddItem("5", rolls[3], Color.Yellow)
                .AddItem("6", rolls[4], Color.Yellow)
                .AddItem("7", rolls[5], Color.Yellow)
                .AddItem("8", rolls[6], Color.Yellow)
                .AddItem("9", rolls[7], Color.Yellow)
                .AddItem("10", rolls[8], Color.Yellow)
                .AddItem("11", rolls[9], Color.Yellow)
                .AddItem("12", rolls[10], Color.Yellow)
            );
        }
    }
}
