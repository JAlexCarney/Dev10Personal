using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotel
{
    interface IHotel
    {
        public string Capacity { get; set; }

        public void ViewHotel();

        public void CheckIn();

        public void CheckOut();
    }
}
