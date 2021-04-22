using System;
using WeatherAlmanac.Core;
using WeatherAlmanac.BLL;

namespace WeatherAlmanac.UI
{
    public class WeatherAlmanacController
    {
        IRecordService _recordService;

        public WeatherAlmanacController(IRecordService recordService) 
        {
            _recordService = recordService;
        }

        public void Run() 
        {
            
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
                        var resultList = _recordService.LoadRange(
                            ConsoleIO.GetDateTime("Enter start date: "),
                            ConsoleIO.GetDateTime("Enter end date: "));
                        if (resultList.Success)
                        {
                            ConsoleIO.DisplaySuccess(resultList.Message);

                            foreach (var record in resultList.Data) 
                            {
                                ConsoleIO.DisplayDateRecord(record);
                            }
                        }
                        else
                        {
                            ConsoleIO.DisplayFailure(resultList.Message);
                        }
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
                        result = _recordService.Edit(ConsoleIO.GetDateTime("Enter Date to be Edited: "), ConsoleIO.GetDateRecord());
                        if (result.Success)
                        {
                            ConsoleIO.DisplaySuccess(result.Message);
                        }
                        else
                        {
                            ConsoleIO.DisplayFailure(result.Message);
                        }
                        break;
                    case 5:
                        // Delete Record
                        result = _recordService.Remove(ConsoleIO.GetDateTime("Enter the date to remove: "));
                        if (result.Success)
                        {
                            ConsoleIO.DisplaySuccess(result.Message);
                        }
                        else
                        {
                            ConsoleIO.DisplayFailure(result.Message);
                        }
                        break;
                    case 6:
                        // Quit
                        return;
                }

                // Prompt Continue so user can see printed output before clear
                ConsoleIO.PromptContinue();
            }
        }
    }
}
