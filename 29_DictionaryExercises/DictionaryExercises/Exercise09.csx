using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 1. Print the size of `vehicles`.
            // 2. Remove VIN 2G4WD582061270646
            // 3. Remove VIN 1M8GDM9AXKP042788
            // 4. Print the size of `vehicles`. (Expected: 999)
        }
    }
}
