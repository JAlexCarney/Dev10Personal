using System;

namespace ConnectFour.Engine
{
    public interface IPlayer
    {
        public bool IsFirst { get; set; }
        public int MakeChoice();
    }
}
