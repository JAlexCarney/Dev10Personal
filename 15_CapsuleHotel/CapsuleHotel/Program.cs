using System;

namespace CapsuleHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            // display header
            WriteWithColor("Welcome to Capsule-Capsule\n", ConsoleColor.Yellow);
            WriteWithColor("===========================\n", ConsoleColor.DarkYellow);

            // initialize hotel array
            int hotelCapacity = GetIntInRange("Enter the number of capsules available: ", 1, int.MaxValue);
            string[] hotel = new string[hotelCapacity];

            // Display success
            WriteWithColor($"\nThere are {hotel.Length} unoccupied capsules ready to be booked.\n", ConsoleColor.Green);
            PromptContinue();

            // enter menu
            MenuLoop(hotel);
        }

        /// <summary>
        /// Waits for user to enter any key
        /// </summary>
        static void PromptContinue() 
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays a string using a color instead of just white
        /// </summary>
        /// <param name="toWrite">The string to display</param>
        /// <param name="color">The color to display it in</param>
        static void WriteWithColor(string toWrite, ConsoleColor color) 
        {
            Console.ForegroundColor = color;
            Console.Write(toWrite);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Creates a menu that can perform hotel adim actions
        /// </summary>
        /// <param name="hotel">The hotel the menu can change/view</param>
        static void MenuLoop(string[] hotel) 
        {
            // loop exited by return statement
            while (true) 
            {
                // Make sure area is clear
                Console.Clear();

                // display header
                WriteWithColor("Guest Menu\n", ConsoleColor.Yellow);
                WriteWithColor("==========\n", ConsoleColor.DarkYellow);
                WriteWithColor("1. Check In\n", ConsoleColor.Yellow);
                WriteWithColor("2. Check Out\n", ConsoleColor.Yellow);
                WriteWithColor("3. View Guests\n", ConsoleColor.Yellow);
                WriteWithColor("4. Exit\n", ConsoleColor.Yellow);

                // get user selection
                int selection = GetIntInRange($"Choose an option [1-4] ", 1, 4);

                // Clear screen
                Console.Clear();

                switch (selection)
                {
                    case 1: // Check In
                        CheckIn(hotel);
                        break;
                    case 2: // Check Out
                        CheckOut(hotel);
                        break;
                    case 3: // View Guests
                        ViewHotel(hotel);
                        break;
                    case 4: // Exit
                        if (Exit()) 
                        {
                            Console.Clear();
                            WriteWithColor("Goodbye!\n\n", ConsoleColor.Yellow);
                            return;
                        }
                        break;
                    default:
                        break;
                }

                // prompt before next loop
                PromptContinue();
            }
        }
        
        /// <summary>
        /// Prompts the user for a string and returns once the user enters a valid one
        /// </summary>
        /// <param name="prompt">The prompt that the user sees</param>
        /// <returns>The first valid string that the user enters</returns>
        static string GetString(string prompt) 
        {
            string output;
            do
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                output = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (string.IsNullOrEmpty(output));
            return output;
        }

        /// <summary>
        /// repeatedly Prompts the user for an int and only returns once they have
        /// entered a valid int in the given range
        /// </summary>
        /// <param name="prompt">The prompt shown to the user</param>
        /// <param name="min">The smallest valid int</param>
        /// <param name="max">The largest valid int</param>
        /// <returns>The first valid int entered by the user</returns>
        static int GetIntInRange(string prompt, int min, int max)
        {
            int output;
            string input;
            do
            {
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (!int.TryParse(input, out output) || output < min || output > max);

            return output;
        }

        /// <summary>
        /// Prompts the user for a room number and shows the 10 nearest rooms in numerical order
        /// </summary>
        /// <param name="hotel">This array is used to display names and is not altered</param>
        static void ViewHotel(string[] hotel) 
        {
            // Display header
            WriteWithColor("View Guests\n", ConsoleColor.Yellow);
            WriteWithColor("===========\n", ConsoleColor.DarkYellow);
            
            // Get room admin wants to view around
            int roomIndex = GetIntInRange($"Capsule #[1-{hotel.Length}] ", 1, hotel.Length) - 1;
            
            // set index to start viewing
            int veiwingIndex = roomIndex - 5;
            if (veiwingIndex < 0) { veiwingIndex = 0; }
            
            // set index to end viewing
            int endIndex = roomIndex + 5;
            if (endIndex > hotel.Length - 1) { endIndex = (hotel.Length - 1); }

            // display selected rooms
            WriteWithColor("\nCapsule : Guest\n", ConsoleColor.Yellow);
            for (int i = veiwingIndex; i <= endIndex; i++) 
            {
                WriteWithColor($"{i+1,7:###.} : ", ConsoleColor.Yellow);
                if (string.IsNullOrEmpty(hotel[i]))
                {
                    WriteWithColor($"[unoccupied]\n", ConsoleColor.Green);
                }
                else 
                {
                    WriteWithColor($"{hotel[i]}\n", ConsoleColor.DarkYellow);
                }
            }
        }

        /// <summary>
        /// takes in the hotel and alteres it to add a guest
        /// </summary>
        /// <param name="hotel">The string array for the hotel, it will be altered</param>
        static void CheckIn(string[] hotel) 
        {
            // Display header
            WriteWithColor("Guest Check In\n", ConsoleColor.Yellow);
            WriteWithColor("==============\n", ConsoleColor.DarkYellow);

            // make sure hotel isn't full
            // can't check out if hotel is empty
            if (isFull(hotel))
            {
                WriteWithColor($"Error :(\nThe hotel is fully booked.\n", ConsoleColor.Red);
                return;
            }

            // Get name of person admin wants to check in
            string guestName = GetString($"Guest Name: ");

            // attempt to fill room
            bool isCheckedIn = false;
            while (!isCheckedIn) 
            {
                // Get room admin wants to check them into
                int roomIndex = GetIntInRange($"Capsule #[1-{hotel.Length}] ", 1, hotel.Length) - 1;

                if (string.IsNullOrEmpty(hotel[roomIndex]))
                {
                    hotel[roomIndex] = guestName;
                    WriteWithColor($"Success :)\n{guestName} is booked in capsule #{roomIndex+1}.\n", ConsoleColor.Green);
                    isCheckedIn = true;
                }
                else 
                {
                    WriteWithColor($"Error :(\nCapsule #{roomIndex+1} is already occupied.\n", ConsoleColor.Red);
                }
            }

        }

        static bool isEmpty(string[] array) 
        {
            foreach (string s in array)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    return false;
                }
            }
            return true;
        }

        static bool isFull(string[] array)
        {
            foreach (string s in array)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// takes in the hotel and alteres it to remove a guest
        /// </summary>
        /// <param name="hotel">This contains the guest names and it will be altered</param>
        static void CheckOut(string[] hotel)
        {
            // Display header
            WriteWithColor("Guest Check Out\n", ConsoleColor.Yellow);
            WriteWithColor("===============\n", ConsoleColor.DarkYellow);

            // make sure hotel isn't empty
            // can't check out if hotel is empty
            if (isEmpty(hotel)) 
            {
                WriteWithColor($"Error :(\nThere is no one in the hotel to check out.\n", ConsoleColor.Red);
                return;
            }

            // attempt to free room
            bool isCheckedIn = true;
            while (isCheckedIn)
            {
                // Get room admin wants to check them into
                int roomIndex = GetIntInRange($"Capsule #[1-{hotel.Length}] ", 1, hotel.Length) - 1;

                if (!string.IsNullOrEmpty(hotel[roomIndex]))
                {
                    WriteWithColor($"Success :)\n{hotel[roomIndex]} checked out from capsule #{roomIndex + 1}.\n", ConsoleColor.Green);
                    hotel[roomIndex] = null;
                    isCheckedIn = false;
                }
                else
                {
                    WriteWithColor($"Error :(\nCapsule #{roomIndex + 1} is unoccupied.\n", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Prompts user if they would really like to exit
        /// </summary>
        static bool Exit() 
        {
            // Display header
            WriteWithColor("Exit\n", ConsoleColor.Yellow);
            WriteWithColor("====\n", ConsoleColor.DarkYellow);
            WriteWithColor("Are you sure you want to exit?\n", ConsoleColor.Yellow);
            WriteWithColor("All data will be lost.", ConsoleColor.Yellow);
            
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
    }
}