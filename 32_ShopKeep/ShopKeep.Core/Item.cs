using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeep.Core
{
    public class Item
    {
        public char DisplayChar { get; set; }
        public ConsoleColor DisplayColor { get; set; }
        public int Value { get; set; }

        private static readonly Random _rng = new ();
        private static readonly string validChars = @"+#$%@&(){}µσ£ÜΣßπΘΩ∞φ≥≤⌠±╬∩≈Å¥¿▓▒░«»½¼";

        public static Item RandomItem() 
        {
            var item = new Item
            {
                DisplayColor = ConsoleIO.RandomConsoleColor(),
                DisplayChar = validChars[_rng.Next(validChars.Length)],
                Value = _rng.Next(10, 300)
            };
            return item;
        }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   DisplayChar == item.DisplayChar &&
                   DisplayColor == item.DisplayColor &&
                   Value == item.Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
