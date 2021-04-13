using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotel
{
    class InfiniteHotel : IHotel
    {
        private List<Guest> _guests;
        private double _costPerNight;
        public string Capacity { get => "∞"; set { } }

        public InfiniteHotel(double costPerNight)
        {
            _guests = new List<Guest>();
            _costPerNight = costPerNight;
        }

        /// <summary>
        /// Prompts the user for a room number and shows the 10 nearest rooms in numerical order
        /// </summary>
        public void ViewHotel()
        {
            // Display header
            ConsoleIO.WriteWithColor("View Guests\n", ConsoleColor.Yellow);
            ConsoleIO.WriteWithColor("===========\n", ConsoleColor.DarkYellow);

            // make sure hotel isn't empty
            // can't check out if hotel is empty
            if (_guests.Count == 0)
            {
                ConsoleIO.WriteWithColor($"Error :(\nThere is no one in the hotel to check out.\n", ConsoleColor.Red);
                return;
            }

            // Get room admin wants to view around
            int roomIndex = ConsoleIO.GetIntInRange($"Capsule #[1-{_guests.Count}] ", 1, _guests.Count) - 1;

            // set index to start viewing
            int veiwingIndex = roomIndex - 5;
            if (veiwingIndex < 0) { veiwingIndex = 0; }

            // set index to end viewing
            int endIndex = roomIndex + 5;
            if (endIndex > _guests.Count - 1) { endIndex = (_guests.Count - 1); }

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
                    ConsoleIO.WriteWithColor($"{_guests[i]}\n", ConsoleColor.DarkYellow);
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

            // Get name of person admin wants to check in
            string guestName = ConsoleIO.GetString($"Guest Name: ");

            // Get the length of their stay
            DateTime checkOutDate = ConsoleIO.GetFutureDateTime($"Check Out Date: ");

            // attempt to fill room
            bool isCheckedIn = false;
            while (!isCheckedIn)
            {                
                _guests.Add(new Guest(guestName, DateTime.Now, checkOutDate));
                ConsoleIO.WriteWithColor($"Success :)\n{guestName} is booked in a capsule.\n", ConsoleColor.Green);
                isCheckedIn = true;
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
            if (_guests.Count == 0)
            {
                ConsoleIO.WriteWithColor($"Error :(\nThere is no one in the hotel to check out.\n", ConsoleColor.Red);
                return;
            }

            // attempt to free room
            bool isCheckedIn = true;
            while (isCheckedIn)
            {
                // Get room admin wants to check them into
                int roomIndex = ConsoleIO.GetIntInRange($"Capsule #[1-{_guests.Count}] ", 1, _guests.Count) - 1;

                if (_guests[roomIndex] != null)
                {
                    TimeSpan lengthOfStay = _guests[roomIndex].CheckOutTime.Subtract(_guests[roomIndex].CheckInTime);
                    ConsoleIO.WriteWithColor($"Success :)\n{_guests[roomIndex].Name} checked out from capsule #{roomIndex + 1}\nThey were charged {((lengthOfStay.Days + 1) * _costPerNight):C}.\nThey stayed for {lengthOfStay.Days + 1} nights.\n", ConsoleColor.Green);
                    _guests.RemoveAt(roomIndex);
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
