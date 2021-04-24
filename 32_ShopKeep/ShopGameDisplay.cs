using System;
using System.Collections.Generic;
using ShopKeep.Core;

namespace ShopKeep
{
    public static class ShopGameDisplay
    {
        public static void DisplayHeader(ShopKeeper shopKeeper)
        {
            DrawShopKeep(shopKeeper.Cart.ForSale, shopKeeper.Cart.Capacity);
            ConsoleIO.WriteWithColor($"Name     : {shopKeeper.Name}\n", ConsoleColor.Cyan);
            ConsoleIO.WriteWithColor($"Distance : {shopKeeper.DistanceTraveled} miles\n", ConsoleColor.Cyan);
            ConsoleIO.WriteWithColor($"Gold     : {shopKeeper.Gold}$\n", ConsoleColor.Cyan);
            ConsoleIO.WriteWithColor("============================================\n", ConsoleColor.Cyan);
        }

        public static void UpdateCart(ShopKeeper shopKeeper) 
        {
            int x = Console.GetCursorPosition().Left;
            int y = Console.GetCursorPosition().Top;
            Console.SetCursorPosition(0, 0);
            DrawShopKeep(shopKeeper.Cart.ForSale, shopKeeper.Cart.Capacity);
            Console.SetCursorPosition(x, y);
        }

        public static void UpdateStats(ShopKeeper shopKeeper) 
        {
            int x = Console.GetCursorPosition().Left;
            int y = Console.GetCursorPosition().Top;
            Console.SetCursorPosition(0, 8);
            ConsoleIO.WriteWithColor($"Name     : {shopKeeper.Name}\n", ConsoleColor.Cyan);
            ConsoleIO.WriteWithColor($"Distance : {shopKeeper.DistanceTraveled} miles\n", ConsoleColor.Cyan);
            ConsoleIO.WriteWithColor($"Gold     : {shopKeeper.Gold}\n", ConsoleColor.Cyan);
            Console.SetCursorPosition(x, y);
        }

        public static void DrawShopKeep(List<Item> items, int capacity)
        {
            ConsoleColor cartColor = ConsoleColor.DarkYellow;
            ConsoleColor salesmanColor = ConsoleColor.DarkCyan;
            ConsoleColor UmbrellaColor = ConsoleColor.DarkGreen;

            ConsoleIO.WriteWithColor("   _______\n", UmbrellaColor);
            ConsoleIO.WriteWithColor("  / / | \\ \\\n", UmbrellaColor);
            ConsoleIO.WriteWithColor("  ^^^^|^^^^\n", UmbrellaColor);
            ConsoleIO.WriteWithColor("      |\n", UmbrellaColor);
            ConsoleIO.WriteWithColor("  ()()", salesmanColor);
            ConsoleIO.WriteWithColor("|\n", UmbrellaColor);
            ConsoleIO.WriteWithColor("  (-.-)\n", salesmanColor);
            ConsoleIO.WriteWithColor("  (v v)\n", salesmanColor);
            int row = Console.CursorTop - 4;
            Console.SetCursorPosition(8, row);
            ConsoleIO.WriteWithColor(" ", salesmanColor);
            for (int i = 0; i < items.Count; i++)
            {
                ConsoleIO.WriteWithColor($" {items[i].DisplayChar} ", items[i].DisplayColor);
            }
            if (items.Count < 5)
            {
                Console.Write(new String(' ', (5 - items.Count) * 3));
            }
            Console.SetCursorPosition(8, row + 1);
            ConsoleIO.WriteWithColor("▄", cartColor);
            for (int i = 0; i < capacity; i++)
            {
                ConsoleIO.WriteWithColor($"▄█▄", cartColor);
            }
            ConsoleIO.WriteWithColor("▄", cartColor);
            Console.SetCursorPosition(8, row + 2);
            ConsoleIO.WriteWithColor("\\", cartColor);
            for (int i = 0; i < capacity; i++)
            {
                ConsoleIO.WriteWithColor($"___", cartColor);
            }
            ConsoleIO.WriteWithColor("/", cartColor);
            ConsoleIO.DrawHorse(11 + (capacity * 3), row, ConsoleColor.DarkCyan);
            Console.SetCursorPosition(8, row + 3);
            ConsoleIO.WriteWithColor("0", cartColor);
            for (int i = 0; i < capacity; i++)
            {
                ConsoleIO.WriteWithColor($"---", cartColor);
            }
            ConsoleIO.WriteWithColor("0", cartColor);
            Console.WriteLine();
            ConsoleIO.WriteWithColor("============================================\n", ConsoleColor.Cyan);
        }
    }
}
