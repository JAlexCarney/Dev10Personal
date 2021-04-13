using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 1. Retrieve the vehicle with the VIN: 1M8GDM9AXKP042788 from `vehicles`. Store the vehicle in a variable.
            // (The operation should fail. The key does not exist in the map.)

            // 2. Try a second time but first confirm the key exists with the `ContainsKey` method.
            // Don't let the program crash.
        }
    }
}
