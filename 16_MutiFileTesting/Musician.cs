using System;
using System.Collections.Generic;
using System.Text;

namespace MutiFileTesting
{
    public class Musician
    {
        public int Rating { get; set; }
        public string Name { get; set; }

        public Musician()
        {
            Name = "";
            Rating = 0;
        }

        /// <summary>
        /// Represents a musical artist.
        /// </summary>
        /// <param name="name">The name of the musician.</param>
        /// <param name="rating">A number representing how much a musician is loved relative to other musicians.</param>
        public Musician(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
    }
}
