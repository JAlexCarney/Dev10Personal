using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotel
{
    class Guest
    {
        public int Nights { get; private set; }
        public string Name { get; private set; }

        public Guest(string name, int nights) 
        {
            Name = name;
            Nights = nights;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
