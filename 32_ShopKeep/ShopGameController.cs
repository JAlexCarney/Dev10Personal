using System;
using ShopKeep.Core;

namespace ShopKeep
{
    class ShopGameController
    {
        public ShopKeeper ShopKeeper { get; set; }
        private readonly Random _rng = new ();
        private int theifSteals = 100;
        private double theifChance = 0.1;

        public void Run() 
        {
            ShopKeeper = new ShopKeeper(ConsoleIO.GetString("What is your Name : "));

            GameLoop();
        }

        private void GameLoop() 
        {
            while (ShopKeeper.Gold > 0) 
            {
                // Draw cart and ground
                Console.Clear();
                ShopGameDisplay.DisplayHeader(ShopKeeper);
                
                if (ShopKeeper.DistanceTraveled == 0) 
                {
                    ConsoleIO.WriteWithColor($"*You start on your journey*\n", ConsoleColor.Yellow);
                }

                Travel(100);

                if (ShopKeeper.DistanceTraveled % 500 == 0 && _rng.NextDouble() < theifChance)
                {
                    EncounterThieves();
                }
                else if (ShopKeeper.DistanceTraveled % 600 == 0)
                {
                    EncounterSavePoint();
                }
                else if (_rng.Next(5) == 0)
                {
                    EncounterCustomer();
                }
                else if (_rng.Next(5) == 0) 
                {
                    EncounterSupplier();
                }
                else
                {
                    ConsoleIO.WriteWithColor($"*It was pretty uneventfull*\n", ConsoleColor.Yellow);
                }
                
                ConsoleIO.PromptContinue();
            }
        }

        private void Travel(int distance) 
        {
            ConsoleIO.WriteWithColor($"*You travel {distance} miles*\n", ConsoleColor.Yellow);
            ShopKeeper.DistanceTraveled += distance;
            ShopGameDisplay.UpdateStats(ShopKeeper);
        }

        private void EncounterSavePoint() 
        {
            ConsoleIO.WriteWithColor("*You are offered slight protection from theives for 100 Gold*\n", ConsoleColor.Yellow);
            if (ConsoleIO.GetYesOrNo("Would you like to buy protection from theives? [y/n]: "))
            {
                ConsoleIO.WriteWithColor("*You purchase protection from theives*\n", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor("*The chance of theives does not increase*\n", ConsoleColor.Green);
                ShopKeeper.Gold -= 100;
            }
            else 
            {
                ConsoleIO.WriteWithColor("*You enter a rougher path*\n", ConsoleColor.Red);
                ConsoleIO.WriteWithColor("*The chance of theives increases*\n", ConsoleColor.Red);
                theifChance += 0.02;
            }
            ShopGameDisplay.UpdateStats(ShopKeeper);
        }

        private void EncounterThieves() 
        {
            ConsoleIO.WriteWithColor($"*You encounter THIEVES!*\n", ConsoleColor.Red);
            ConsoleIO.WriteWithColor($"*{theifSteals} Gold is stolen*\n", ConsoleColor.Red);
            ShopKeeper.Gold -= theifSteals;
            ShopGameDisplay.UpdateStats(ShopKeeper);
            theifSteals += 10;
        }

        private void EncounterSupplier() 
        {
            ConsoleIO.WriteWithColor($"*You encounter a potential supplier*\n", ConsoleColor.Yellow);
            if (ShopKeeper.Cart.ForSale.Count == ShopKeeper.Cart.Capacity) 
            {
                ConsoleIO.WriteWithColor($"*They see that your cart is full*\n", ConsoleColor.Red);
                ConsoleIO.WriteWithColor($"*The supplier leaves dissatisfied*\n", ConsoleColor.Yellow);
                return;
            }

            ConsoleIO.WriteWithColor($"*They offer to sell you their ", ConsoleColor.Green);

            Item newItem = Item.RandomItem();

            ConsoleIO.WriteWithColor($"{newItem.DisplayChar}", newItem.DisplayColor);
            ConsoleIO.WriteWithColor($" for {newItem.Value} gold*\n", ConsoleColor.Green);

            if (ConsoleIO.GetYesOrNo("Would you like to buy it? [y/n]: "))
            {
                ConsoleIO.WriteWithColor($"*You buy their ", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor($"{newItem.DisplayChar}", newItem.DisplayColor);
                ConsoleIO.WriteWithColor($" for {newItem.Value} gold*\n", ConsoleColor.Yellow);

                ShopKeeper.Gold -= newItem.Value;
                ShopKeeper.Cart.ForSale.Add(newItem);

                ShopGameDisplay.UpdateStats(ShopKeeper);
                ShopGameDisplay.UpdateCart(ShopKeeper);
            }
            else
            {
                ConsoleIO.WriteWithColor($"*The supplier leaves dissatisfied*", ConsoleColor.Yellow);
            }
        }
        
        private void EncounterCustomer() 
        {
            ConsoleIO.WriteWithColor($"*You encounter a potential customer*\n", ConsoleColor.Yellow);
            if (ShopKeeper.Cart.ForSale.Count == 0) 
            {
                ConsoleIO.WriteWithColor($"*They see that you have nothing to sell*\n", ConsoleColor.Red);
                ConsoleIO.WriteWithColor($"*The customer leaves dissatisfied*", ConsoleColor.Yellow);
                return;
            }
            ConsoleIO.WriteWithColor($"*They offer to purchess your ", ConsoleColor.Green);

            Item interested = ShopKeeper.Cart.ForSale[_rng.Next(ShopKeeper.Cart.ForSale.Count)];
            ConsoleIO.WriteWithColor($"{interested.DisplayChar}", interested.DisplayColor);
            
            int offer = interested.Value + _rng.Next(-interested.Value/2, interested.Value * 2);

            ConsoleIO.WriteWithColor($" for {offer} gold*\n", ConsoleColor.Green);

            if (ConsoleIO.GetYesOrNo("Would you like to sell it? [y/n]: "))
            {
                ConsoleIO.WriteWithColor($"*You sell your ", ConsoleColor.Yellow);
                ConsoleIO.WriteWithColor($"{interested.DisplayChar}", interested.DisplayColor);
                ConsoleIO.WriteWithColor($" for {offer} gold*\n", ConsoleColor.Yellow);

                ShopKeeper.Gold += offer;
                ShopKeeper.Cart.RemoveItem(interested);

                ShopGameDisplay.UpdateStats(ShopKeeper);
                ShopGameDisplay.UpdateCart(ShopKeeper);
            }
            else 
            {
                ConsoleIO.WriteWithColor($"*The customer leaves dissatisfied*", ConsoleColor.Yellow);
            }
        }
    }
}
