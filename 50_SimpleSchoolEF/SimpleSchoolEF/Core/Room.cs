using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolEF.Core
{
    public class Room
    {
        public int RoomID { get; set; }
        public int BuildingID { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }
    }
}
