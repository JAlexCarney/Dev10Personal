using DictionaryExercises.Transportation;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Vehicle> vehicles = VehicleRepository.GetDictionary();

            // 1. Replace the vehicle with VIN 2G4WD582061270646 with a new Orange 1994 Chrysler School Bus.
            // 2. Retrieve the new vehicle from `vehicles` and print it to confirm it was updated.
        }
    }
}
