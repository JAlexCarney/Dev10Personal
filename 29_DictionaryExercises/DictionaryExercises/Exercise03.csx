using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        // 1. Create a method to print all Vehicles in a Dictionary<string, Vehicle>.

        public static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 2. Print `vehicles` using your "print all" method.
        }
    }
}

