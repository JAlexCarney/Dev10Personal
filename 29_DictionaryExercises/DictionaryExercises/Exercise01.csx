using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // `vehicles` is a Dictionary that holds 1000 vehicles.
            // The key is the VIN (https://en.wikipedia.org/wiki/Vehicle_identification_number) as a string.
            // The value is an instance of a Vehicle.

            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 1. Retrieve the vehicle with the VIN: 2G4WD582061270646 from `vehicles`. Store the vehicle in a variable.
            // 2. Print it to the console. Confirm it's a Khaki 1989 Buick LeSabre.
        }
    }
}
