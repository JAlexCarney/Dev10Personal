using System;
using System.Collections.Generic;
using System.Text;

namespace MutiFileTesting
{
    class Hero
    {
        public string Name { get; private set; }
        public Power[] Powers { get; private set; }

        public Hero(string name, Power[] powers) 
        {
            Name = name;
            Powers = powers;
        }

        public override string ToString() 
        {
            string s = $"{Name} has the powers :";
            foreach (Power power in Powers) 
            {
                s += " " + power.Name;
            }
            return s;
        }
    }
}
