using System;
using System.Collections.Generic;
using System.Text;

namespace MutiFileTesting
{
    class Balloon
    {
        private Random _rng = new Random();
        private double _psi; // backing field
        public bool IsExploded 
        {
            get 
            {
                return Psi > 16.0;
            }
        }
        public string Color { get; private set; }
        public double Psi 
        {
            get 
            {
                return _psi >= 16.0 ? double.PositiveInfinity : _psi;
            }

            private set 
            {
                _psi = value;
            }
        
        } // lbs/sq inch

        public Balloon(string color) 
        {
            Color = color;
        }

        public void Inflate() 
        {
            Psi += _rng.NextDouble() * 5;

        }
    }
}
