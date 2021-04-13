using DictionaryExercises.Transportation;
using System;
using System.Collections.Generic;

namespace DictionaryExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<Color> colors = new HashSet<Color>();

            colors.Add(new Color("Red"));
            colors.Add(new Color("Red"));
            colors.Add(new Color("Blue"));
            colors.Add(new Color("Red"));
            colors.Add(new Color("Yellow"));
            colors.Add(new Color("Red"));
            colors.Add(new Color("Blue"));
            colors.Add(new Color("Blue"));
            colors.Add(new Color("Red"));
            colors.Add(new Color("Yellow"));
            colors.Add(new Color("Yellow"));
            colors.Add(new Color("Blue"));
            colors.Add(new Color("Red"));

            // A HashSet is designed to prevent duplicate values.
            // Currently, each new Color is treated as a distinct value because class equality is the default reference
            // equality.
            // 1. Override the .Equals and .GetHashCode in Color to compare values, not references.
            // 2. Confirm colors.Count is 3, not 13, below.

            Console.WriteLine(colors.Count);
        }
    }
}
