using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Engine
{
    public class RandomPlayer : IPlayer
    {
        public bool IsFirst { get; set; }
        private Random rng = new Random();

        public int MakeChoice() 
        {
            return rng.Next(7);
        }
    }
}
