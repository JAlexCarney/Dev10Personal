using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotel
{
    class Hotel
    {
        private Guest[] _guests;
        private double _costPerNight;
        public int Length { get => _guests.Length; }

        public Hotel(int numGuests, double costPerNight) 
        {
            _guests = new Guest[numGuests];
            _costPerNight = costPerNight;
        }

        /// <summary>
        /// Returns true if there are no guests
        /// </summary>
        /// <returns>true if there are no guests</returns>
        private bool isEmpty()
        {
            foreach (Guest g in _guests)
            {
                if (g != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true if there are no open rooms
        /// </summary>
        /// <returns>true if there are no open rooms</returns>
        private bool isFull()
        {
            foreach (Guest g in _guests)
            {
                if (g == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Prompts the user for a room number and shows the 10 nearest rooms in numerical order
        /// </summary>
        public void ViewHotel()
        {
            // Display header
            ConsoleIO.WriteWithColor("View Guests\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("===========\n", ConsoleColor.DarkYellow);

            // Get room admin wants to view around
            int roomIndex = ConsoleIO.GetIntInRange($"Capsule #[1-{_guests.Length}] ", 1, _guests.Length) - 1;

            // set index to start viewing
            int veiwingIndex = roomIndex - 5;
            if (veiwingIndex < 0) { veiwingIndex = 0; }

            // set index to end viewing
            int endIndex = roomIndex + 5;
            if (endIndex > _guests.Length - 1) { endIndex = (_guests.Length - 1); }

            // display selected rooms
            ConsoleIO.WriteWithColor("\nCapsule : Guest\n", ConsoleColor.Yellow);
            for (int i = veiwingIndex; i <= endIndex; i++)
            {
                ConsoleIO.WriteWithColor($"{i + 1,7:###.} : ", ConsoleColor.Yellow);
                if (_guests[i] == null)
                {
                    ConsoleIO.WriteWithColor($"[unoccupied]\n", ConsoleColor.Green);
                }
                else
                {
                    ConsoleIO.WriteWithColor($"{_guests[i]} -> {_guests[i].Nights} Nights\n", ConsoleColor.DarkYellow);
                }
            }
        }

        /// <summary>
        /// takes in the hotel and alteres it to add a guest
        /// </summary>
        public void CheckIn()
        {
            // Display header
            ConsoleIO.WriteWithColor("Guest Check In\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("==============\n", ConsoleColor.DarkYellow);

            // make sure hotel isn't full
            // can't check out if hotel is empty
            if (isFull())
            {
                ConsoleIO.WriteWithColor($"Error :(\nThe hotel is fully booked.\n", ConsoleColor.Red);
                return;
            }

            // Get name of person admin wants to check in
            string guestName = ConsoleIO.GetString($"Guest Name: ");

            // Get the length of their stay
            int lengthOfStay = ConsoleIO.GetIntInRange($"Length of Stay: ", 1, int.MaxValue);

            // attempt to fill room
            bool isCheckedIn = false;
            while (!isCheckedIn)
            {
                // Get room admin wants to check them into
                int roomIndex = ConsoleIO.GetIntInRange($"Capsule #[1-{_guests.Length}] ", 1, _guests.Length) - 1;

                if (_guests[roomIndex] == null)
                {
                    _guests[roomIndex] = new Guest(guestName, lengthOfStay);
                    ConsoleIO.WriteWithColor($"Success :)\n{guestName} is booked in capsule #{roomIndex + 1}.\n", ConsoleColor.Green);
                    isCheckedIn = true;
                }
                else
                {
                    ConsoleIO.WriteWithColor($"Error :(\nCapsule #{roomIndex + 1} is already occupied.\n", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// takes in the hotel and alteres it to remove a guest
        /// </summary>
        public void CheckOut()
        {
            // Display header
            ConsoleIO.WriteWithColor("Guest Check Out\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("===============\n", ConsoleColor.DarkYellow);

            // make sure hotel isn't empty
            // can't check out if hotel is empty
            if (isEmpty())
            {
                ConsoleIO.WriteWithColor($"Error :(\nThere is no one in the hotel to check out.\n", ConsoleColor.Red);
                return;
            }

            // attempt to free room
            bool isCheckedIn = true;
            while (isCheckedIn)
            {
                // Get room admin wants to check them into
                int roomIndex = ConsoleIO.GetIntInRange($"Capsule #[1-{_guests.Length}] ", 1, _guests.Length) - 1;

                if (_guests[roomIndex] != null)
                {
                    ConsoleIO.WriteWithColor($"Success :)\n{_guests[roomIndex]} checked out from capsule #{roomIndex + 1} and was charged {(_guests[roomIndex].Nights * _costPerNight):C}.\n", ConsoleColor.Green);
                    _guests[roomIndex] = null;
                    isCheckedIn = false;
                }
                else
                {
                    ConsoleIO.WriteWithColor($"Error :(\nCapsule #{roomIndex + 1} is unoccupied.\n", ConsoleColor.Red);
                }
            }
        }
    }
}
