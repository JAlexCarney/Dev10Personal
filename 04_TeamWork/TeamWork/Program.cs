using System;
using System.Text;

namespace TeamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt user for pizza
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Would you like a ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Pizza");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("?\n");

            

            // create order string
            StringBuilder order = new StringBuilder();
            order.Append("You're order is a ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string ans = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (ans.ToLower().Contains("yes"))
            {
                // you do want pizza
                // Options of cheese, cheese + pep, cheese + mushroom, Hawaiian

                // added up throught ordering proccess
                decimal price = 0M;

                // what size would you like?
                Console.WriteLine("What size would you like? (small, medium, large)");
                Console.ForegroundColor = ConsoleColor.Blue;
                string sizeChoice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;


                // switch
                // What is the price
                // small: 5.00 medium: $8.00 Large:$10.00
                switch (sizeChoice) 
                {
                    case "small":
                        price += 5M;
                        order.Append("small with: (");
                        break;
                    case "medium":
                        price += 8M;
                        order.Append("medium with: (");
                        break;
                    case "large":
                        price += 10M;
                        order.Append("large with: (");
                        break;
                }

                // get user toppings
                Console.WriteLine("Would you like peperoni?");
                Console.ForegroundColor = ConsoleColor.Blue;
                ans = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (ans.ToLower().Contains("yes")) 
                {
                    price += 1M;
                    order.Append("peperoni ");

                }

                Console.WriteLine("Would you like mushrooms?");
                Console.ForegroundColor = ConsoleColor.Blue;
                ans = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (ans.ToLower().Contains("yes"))
                {
                    price += 1M;
                    order.Append("mushrooms ");
                }

                Console.WriteLine("Would you like hawaiian?");
                Console.ForegroundColor = ConsoleColor.Blue;
                ans = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (ans.ToLower().Contains("yes"))
                {
                    price += 3M;
                    order.Append("hawaiian ");
                }

                order.Append($"), It will cost {price:C}.");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(order);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else 
            {
                // you do not want pizza :(
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO PIZZA?!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
    }
}
