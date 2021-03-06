using System;
using Ninject;
using WeatherAlmanac.Core;

namespace WeatherAlmanac.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display Header
            ConsoleIO.DisplayHeader("Welcome to the Weather Almanac.");
            ConsoleIO.WriteWithColor("What mode would you like to run in?\n\n", ConsoleColor.DarkYellow);

            // Display Menu Options
            ConsoleIO.DisplayMenuOptions(
                "Live",
                "Test");

            // Prompt for implementation
            int choice = ConsoleIO.GetIntInRange("Select mode: ", 1, 2);
            ApplicationMode appMode = (ApplicationMode)(choice - 1);
            
            // Display Menu Options
            ConsoleIO.DisplayMenuOptions(
                "Null",
                "Console",
                "File");

            // Prompt for implementation
            choice = ConsoleIO.GetIntInRange("Select mode: ", 1, 3);
            LoggerMode logMode = (LoggerMode)(choice - 1);

            NinjectContainer.Configure(appMode, logMode);

            var wc = NinjectContainer.Kernel.Get<WeatherAlmanacController>();
            wc.Run();
        }
    }
}
