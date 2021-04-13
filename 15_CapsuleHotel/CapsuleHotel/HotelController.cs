using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotel
{
    class HotelController
    {
        public IHotel Hotel { get; set; }
        public double CostPerNight { get; set; }

        public void Run() 
        {
            // display header
            ConsoleIO.WriteWithColor("Welcome to Capsule-Capsule\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("===========================\n", ConsoleColor.DarkYellow);

            // decide on a IHotel Implementaion
            ConsoleIO.WriteWithColor("\nWhich Hotel Type are you using :\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("1. Finite\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("2. Infinite\n", ConsoleColor.Yellow);

            int choice = ConsoleIO.GetIntInRange("Enter choice : ", 1, 2);

            switch (choice) 
            {
                case 1:
                    Hotel = new Hotel(
                        ConsoleIO.GetIntInRange("Enter the number of capsules available: ", 1, int.MaxValue),
                        ConsoleIO.GetDoubleInRange("Enter the cost per night of a capsule: ", 0.0, double.MaxValue));
                    break;
                case 2:
                    Hotel = new InfiniteHotel(
                        ConsoleIO.GetDoubleInRange("Enter the cost per night of a capsule: ", 0.0, double.MaxValue));
                    break;
            }

            

            // Display success
            ConsoleIO.WriteWithColor($"\nThere are {Hotel.Capacity} unoccupied capsules ready to be booked.\n", ConsoleColor.Green);
            ConsoleIO.PromptContinue();

            // enter menu
            MenuLoop();
        }

        /// <summary>
        /// Prompts user if they would really like to exit
        /// </summary>
        public bool Exit()
        {
            // Display header
            ConsoleIO.WriteWithColor("Exit\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("====\n", ConsoleColor.DarkYellow);
            ConsoleIO.WriteWithColor("Are you sure you want to exit?\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("All data will be lost.", ConsoleColor.Yellow);

            // get either a yes or no from the user
            string userResponse;
            while (true)
            {
                Console.Write("\nExit [y/n]: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                userResponse = Console.ReadKey().KeyChar.ToString().ToLower();
                Console.ForegroundColor = ConsoleColor.White;
                if (userResponse == "y")
                {
                    return true;
                }
                else if (userResponse == "n")
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Creates a menu that can perform hotel adim actions
        /// </summary>
        public void MenuLoop()
        {
            // loop exited by return statement
            while (true)
            {
                // Make sure area is clear
                Console.Clear();

                // display header
                ConsoleIO.WriteWithColor("Guest Menu\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("==========\n", ConsoleColor.DarkYellow);
                ConsoleIO.WriteWithColor("1. Check In\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("2. Check Out\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("3. View Guests\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("4. Exit\n", ConsoleColor.Yellow);

                // get user selection
                int selection = ConsoleIO.GetIntInRange($"Choose an option [1-4] ", 1, 4);

                // Clear screen
                Console.Clear();

                switch (selection)
                {
                    case 1: // Check In
                        Hotel.CheckIn();
                        break;
                    case 2: // Check Out
                        Hotel.CheckOut();
                        break;
                    case 3: // View Guests
                        Hotel.ViewHotel();
                        break;
                    case 4: // Exit
                        if (Exit())
                        {
                            Console.Clear();
                            ConsoleIO.WriteWithColor("Goodbye!\n\n", ConsoleColor.Yellow);
                            return;
                        }
                        break;
                    default:
                        break;
                }

                // prompt before next loop
                ConsoleIO.PromptContinue();
            }
        }
    }
}
