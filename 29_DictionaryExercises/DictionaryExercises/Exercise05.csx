using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 1. Instantiate a new Dictionary<string, Vehicle>.
            // 2. Add two vehicles to the new dictionary.
            // 3. Add items from the new dictionary to `vehicles`.
            // 4. Confirm the vehicles were added by retrieving on with its VIN and printing it to the console.
        }
    }
}
