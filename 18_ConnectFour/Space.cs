using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Space
    {
        public bool IsEmpty { get; set; }
        
        private int _player;
        public int Player 
        {
            get 
            {
                return _player;
            }
            set 
            {
                if (value > 0)
                {
                    _player = value;
                }
                else 
                {
                    IsEmpty = true;
                }
            } 
        }

        public Space() 
        {
            IsEmpty = true;
            _player = -1;
        }

        public override string ToString()
        {
            string output;

            if (IsEmpty)
            {
                output = " ";
            }
            else
            {
                output = "0";
            }

            return output;
        }
    }
}
