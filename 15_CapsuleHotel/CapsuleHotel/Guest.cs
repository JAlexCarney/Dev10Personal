using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotel
{
    class Guest
    {
        
        public string Name { get; private set; }
        public DateTime CheckOutTime { get; private set; }
        public DateTime CheckInTime { get; private set; }

        public Guest(string name, DateTime checkInTime, DateTime checkOutTime) 
        {
            Name = name;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
        }

        public override string ToString()
        {
            return $"{Name} <{CheckInTime:d} => {CheckOutTime:d}>";
        }
    }
}
