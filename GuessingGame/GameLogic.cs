using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame
{
    class GameLogic
    {
        public int Min;
        public int Max;
        private int answer;

        public void GenerateAnswer() 
        {
            Random random = new Random();
            answer = random.Next(Min, Max);
        }

        public string Guess(int guess) 
        {
            if (guess == answer) 
            {
                return "Win";
            }
            if (guess < answer) 
            {
                return "ToLow";
            }
            if (guess > answer) 
            {
                return "ToHigh";
            }
            return null;
        }
    }
}
