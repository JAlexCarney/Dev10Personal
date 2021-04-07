using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtterRaceRefactor
{
    static class RaceLogic
    {
        private static Otter[] racers;
        private static int numRacers;
        private static string[] accidents =
            {
                "slipped on a banana peel",
                "has a cramp",
                "ate too soon before swimming",
                "pulled a hammy",
                "stopped for the toilet",
                "feels too sad to swim right now",
                "is winded"
            };
        private static double chanceOfAccident = 0.1;
        private static Random random = new Random();
        private static double raceDistance;
        private static string message;

        public static void DisplayIntro() 
        {
            // introductions
            message = "Otter Race!";
            Console.WriteLine(message);
            Console.WriteLine(new string('-', message.Length));
            Console.WriteLine();
            Console.WriteLine("(Otters are fiercely competitive and race willingly.");
            Console.WriteLine(" No otters were harmed during the making of this application.)");
            Console.WriteLine();
        }

        public static void SetNumRacersFromUser() 
        {
            do
            {
                Console.Write("How many otters will race?:");
                if (int.TryParse(Console.ReadLine(), out numRacers))
                {
                    if (numRacers < 2 || numRacers > 12)
                    {
                        Console.WriteLine("Racers must be between 2 and 12.");
                    }
                }
                else
                {
                    Console.WriteLine("That's not a number.");
                }
            } while (numRacers < 2 || numRacers > 12);
            Console.WriteLine();
        }

        public static void SetupRacers() 
        {
            // set up racers
            racers = new Otter[numRacers];

            // create otter objects from names
            for (int i = 0; i < numRacers; i++)
            {
                string name;
                do
                {
                    Console.Write($"What is otter #{i + 1}'s name?:");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name is required.");
                    }
                    else if (Otter.ContainsName(racers, name))
                    {
                        Console.WriteLine("Duplicate otter names are not allowed.");
                    }
                } while (string.IsNullOrWhiteSpace(name) || Otter.ContainsName(racers, name));
                racers[i] = new Otter(name);
            }
            Console.WriteLine();
        }

        public static void SetDistance() 
        {
            do
            {
                Console.Write("How long is the race in meters?:");
                if (!double.TryParse(Console.ReadLine(), out raceDistance) && raceDistance <= 0.0)
                {
                    Console.WriteLine("Race distance must be a positive number.");
                }
            } while (raceDistance <= 0.0);
            Console.WriteLine();
        }

        public static void Race() 
        {
            Console.Write("Racers on your mark! [Enter]");
            Console.ReadLine();
            Console.Write("Get set!             [Enter]");
            Console.ReadLine();
            Console.WriteLine("Race!");
            Console.WriteLine();

            int winnerIndex = -1;
            for (int round = 1; winnerIndex == -1; round++)
            {
                // check for a stall
                bool hasStall = false;
                for (int i = 0; i < numRacers; i++)
                {
                    if (random.NextDouble() < chanceOfAccident)
                    {
                        Console.WriteLine($"{racers[i].Name} {accidents[random.Next(accidents.Length)]}!");
                        racers[i].StallDuration += (random.Next(3) + 1);
                        hasStall = true;
                    }
                }

                if (hasStall)
                {
                    Console.WriteLine();
                }

                // move if not stalled
                for (int i = 0; i < numRacers; i++)
                {
                    if (racers[i].StallDuration <= 0)
                    {
                        racers[i].DistanceCovered += random.NextDouble() * 10.0 + 5.0;
                    }
                }

                // report status
                message = $"After {round} round{(round == 1 ? "" : "s")}";
                Console.WriteLine(message);
                Console.WriteLine(new string('=', message.Length));
                for (int i = 0; i < numRacers; i++)
                {
                    Console.WriteLine($"{racers[i].Name} covered {racers[i].DistanceCovered} meters.");
                }
                Console.WriteLine();

                // shrink stall durations by 1
                for (int i = 0; i < numRacers; i++)
                {
                    racers[i].StallDuration = Math.Max(racers[i].StallDuration - 1, 0);
                }

                // check for win
                // more than one otter can cross the finish line in a round.
                // the furthest otter wins.              
                for (int i = 0; i < numRacers; i++)
                {
                    if (racers[i].DistanceCovered > raceDistance)
                    {
                        if (winnerIndex == -1)
                        {
                            winnerIndex = i;
                        }
                        else if (racers[winnerIndex].DistanceCovered < racers[i].DistanceCovered)
                        {
                            winnerIndex = i;
                        }
                    }
                }

                if (winnerIndex == -1)
                {
                    Console.Write("[Enter]");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }

            // declare winner
            message = "Final Results:";
            Console.WriteLine(message);
            Console.WriteLine(new string('=', message.Length));
            Console.WriteLine();
            for (int i = 0; i < numRacers; i++)
            {
                Console.WriteLine($"{racers[i].Name} covered {racers[i].DistanceCovered} meters.");
            }

            Console.WriteLine();

            message = $"{racers[winnerIndex].Name} wins!";
            Console.WriteLine(message);
            Console.WriteLine(new string('=', message.Length));
            Console.WriteLine(new string('=', message.Length));
            Console.WriteLine(new string('=', message.Length));

            Console.WriteLine();
            Console.WriteLine("Goodbye.");
        }
    }
}
