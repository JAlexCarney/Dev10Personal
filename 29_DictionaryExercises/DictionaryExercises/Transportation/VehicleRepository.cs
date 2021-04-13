using System;
using System.Collections.Generic;
using System.IO;

namespace DictionaryExercises.Transportation
{
    public class VehicleRepository
	{
		public static Dictionary<string, Vehicle> GetDictionary()
		{
			Dictionary<string, Vehicle> result = new Dictionary<string, Vehicle>();

			string[] lines = File.ReadAllLines("cars.csv");

			for(int i = 1; i < lines.Length; i++)
			{
				string[] fields = lines[i].Split(",", StringSplitOptions.None);

				if(fields.Length == 5)
				{
					Vehicle vehicle = new Vehicle();
					vehicle.Vin = fields[0];
					vehicle.Make = fields[1];
					vehicle.Model = fields[2];
					vehicle.Year = int.Parse(fields[3]);
					vehicle.Color = fields[4];
					result.Add(vehicle.Vin, vehicle);
				}
			}

			return result;
		}
	}
}
