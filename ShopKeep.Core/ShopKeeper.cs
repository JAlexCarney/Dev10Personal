using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeep.Core
{
    public class ShopKeeper
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public int DistanceTraveled { get; set; }
        public Cart Cart { get; set; }

        public ShopKeeper(string name) 
        {
            Name = name;
            Gold = 1000;
            DistanceTraveled = 0;
            Cart = new Cart(5);
        }
    }
}
