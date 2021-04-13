using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 1. Instantiate a new Dictionary<string, Vehicle> named `twoThousandSix`.
            // 2. Loop through `vehicles` and add all 2006 vehicles to `twoThousandSix`;
            // 3. Loop through `twoThousandSix` and display all vehicles.
            // (You may want to use your print all method from Exercise03.)
            // 4. How many 2006 vehicles are there? (Expected: 50)
        }
    }
}
