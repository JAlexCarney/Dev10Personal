using System;
using System.Linq;

namespace OtterRaceRefactor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display introduction
            RaceLogic.DisplayIntro();

            // gather racer count
            RaceLogic.SetNumRacersFromUser();

            // set up racers
            RaceLogic.SetupRacers();

            // gather race distance
            RaceLogic.SetDistance();

            // race!
            RaceLogic.Race();
        }
    }
}
