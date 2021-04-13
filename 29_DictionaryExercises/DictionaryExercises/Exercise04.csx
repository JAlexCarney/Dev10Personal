using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 1. Create a new Vehicle. Use a VIN that's easy to remember.
            // 2. Add the Vehicle to `vehicles`.
            // 3. Confirm the Vehicle was added by retrieving it and printing it to the console.
        }
    }
}
