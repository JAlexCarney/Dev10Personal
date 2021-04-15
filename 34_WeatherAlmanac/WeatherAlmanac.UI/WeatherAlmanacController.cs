using System;
using WeatherAlmanac.Core;
using WeatherAlmanac.BLL;

namespace WeatherAlmanac.UI
{
    public class WeatherAlmanacController
    {
        IRecordService _recordService;

        public void Run() 
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
            ApplicationMode mode = (ApplicationMode)(choice - 1);

            // Create Record Service with desired mode
            _recordService = RecordServiceFactory.GetRecordService(mode);

            // Enter Main Menu Loop
            MenuLoop();
        }

        public void MenuLoop() 
        {
            // Start MenuLoop
            while (true) 
            {
                // Display Menu Selection Header
                ConsoleIO.DisplayHeader("Main Menu");

                // Display Menu Options
                ConsoleIO.DisplayMenuOptions(
                    "Load a Record",
                    "View Records by Date Range",
                    "Add Record",
                    "Edit Record",
                    "Delete Record",
                    "Exit");

                // Prompt User Choice
                int choice = ConsoleIO.GetIntInRange("Enter Choice: ", 1, 6);
                Result<DateRecord> result;

                // switch on choice
                switch (choice) 
                {
                    case 1:
                        // Load Record
                        result = _recordService.Get(ConsoleIO.GetDateTime("Enter the record date: "));
                        if (result.Success)
                        {
                            ConsoleIO.DisplaySuccess(result.Message);
                            ConsoleIO.DisplayDateRecord(result.Data);
                        }
                        else
                        {
                            ConsoleIO.DisplayFailure(result.Message);
                        }
                        break;
                    case 2:
                        // View Records by Date Range
                        break;
                    case 3:
                        // Add Record
                        result = _recordService.Add(ConsoleIO.GetDateRecord());
                        if (result.Success)
                        {
                            ConsoleIO.DisplaySuccess(result.Message);
                        }
                        else 
                        {
                            ConsoleIO.DisplayFailure(result.Message);
                        }
                        break;
                    case 4:
                        // Edit Record
                        break;
                    case 5:
                        // Delete Record
                        break;
                    case 6:
                        // Quit
                        return;
                }
            }
        }
    }
}
