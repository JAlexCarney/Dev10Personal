using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Engine;

namespace ConnectFour
{
    public class Controller
    {
        private 
        private IPlayer playerOne;
        private IPlayer playerTwo;

        public void Run(IPlayer playerOne, IPlayer playerTwo) 
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            this.playerOne.IsFirst = true;
            this.playerTwo.IsFirst = false;

            GameLoop();
        }

        public void GameLoop() 
        {
            
        }
    }
}
