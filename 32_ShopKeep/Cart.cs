using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeep
{
    class Cart
    {
        public List<Item> ForSale { get; set; }
        public int Capacity { get; set; }

        public Cart(int capacity)
        {
            ForSale = new List<Item>();
            Capacity = capacity;

            for (int i = 0; i < Capacity; i++) 
            {
                ForSale.Add(Item.RandomItem());
            }
        }
    }
}
