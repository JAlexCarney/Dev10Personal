using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeep
{
    public class Item
    {
        public char DisplayChar { get; set; }
        public ConsoleColor DisplayColor { get; set; }
        public int Value { get; set; }

        private static Random _rng = new Random();
        private static string validChars = @"~-+{}[]|:;,.<>/?\#$%@!^&*()µσD£Ü";

        public static Item RandomItem() 
        {
            Item item = new Item();
            item.DisplayColor = ConsoleIO.RandomConsoleColor();
            item.DisplayChar = validChars[_rng.Next(validChars.Length)];
            item.Value = _rng.Next(10, 300);
            return item;
        }
    }
}
