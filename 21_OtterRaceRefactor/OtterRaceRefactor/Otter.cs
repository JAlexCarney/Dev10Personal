using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtterRaceRefactor
{
    class Otter
    {
        public string Name { get; private set; }
        public double DistanceCovered { get; set; }
        public int StallDuration { get; set; }

        public Otter(string name) 
        {
            Name = name;
            DistanceCovered = 0.0;
            StallDuration = 0;
        }

        public static bool ContainsName(Otter[] otters, string name) 
        {
            foreach (Otter otter in otters) 
            {
                if (otter != null && otter.Name == name) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
