using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Engine;

namespace ConnectFour
{
    class HumanPlayer : IPlayer
    {
        public bool IsFirst { get; set; }
        private ConsoleIO io;

        public HumanPlayer(ConsoleIO io) 
        {
            this.io = io;
        }

        public int MakeChoice()
        {
            return io.ReadInt("Enter collumn choice: ", 0, 6);
        }
    }
}
