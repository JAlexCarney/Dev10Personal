using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKeep
{
    class ShopGame
    {
        public ShopKeeper shopKeeper { get; set; }
        private Random rng = new Random();
        private int theifSteals = 100;
        private double theifChance = 0.1;

        public void Run() 
        {
            shopKeeper = new ShopKeeper(ConsoleIO.GetString("What is your Name : "));

            GameLoop();
        }

        public void GameLoop() 
        {
            while (shopKeeper.Gold > 0) 
            {
                // Draw cart and ground
                Console.Clear();
                ConsoleIO.DrawShopKeep(shopKeeper.Cart.ForSale, shopKeeper.Cart.Capacity);
                ConsoleIO.WriteWithColor($"Name     : {shopKeeper.Name}\n", ConsoleColor.Blue);
                ConsoleIO.WriteWithColor($"Distance : {shopKeeper.DistanceTraveled} miles\n", ConsoleColor.Blue);
                ConsoleIO.WriteWithColor($"Gold     : {shopKeeper.Gold}$\n", ConsoleColor.Blue);
                ConsoleIO.WriteWithColor("============================================\n", ConsoleColor.Blue);

                if (shopKeeper.DistanceTraveled == 0) 
                {
                    ConsoleIO.WriteWithColor($"*You start on your journey*\n", ConsoleColor.Yellow);
                    shopKeeper.DistanceTraveled += 100;
                    ConsoleIO.PromptContinue();
                    continue;
                }

                if (shopKeeper.DistanceTraveled % 500 == 0 && rng.NextDouble() < theifChance) 
                {
                    ConsoleIO.WriteWithColor($"*You travel 100 miles and encounter THIEVES!*\n", ConsoleColor.Yellow);
                    ConsoleIO.WriteWithColor($"*{theifSteals} Gold is stolen*\n", ConsoleColor.Yellow);
                    shopKeeper.Gold -= theifSteals;
                    theifSteals += 10;
                }
                else if (shopKeeper.DistanceTraveled % 600 == 0)
                {
                    ConsoleIO.WriteWithColor($"*You travel 100 miles and are offered protection for 100 Gold*\n", ConsoleColor.Yellow);
                    theifChance += 0.02;
                }
                else
                {
                    int encounter = rng.Next(10);
                    switch (encounter)
                    {
                        case 0:
                            ConsoleIO.WriteWithColor($"*You travel 100 miles and encounter a potential customer*\n", ConsoleColor.Yellow);
                            break;
                        default:
                            ConsoleIO.WriteWithColor($"*You travel 100 miles uneventfully*\n", ConsoleColor.Yellow);
                            break;
                    }
                }
                
                shopKeeper.DistanceTraveled += 100;
                ConsoleIO.PromptContinue();
            }
        }
    }
}
