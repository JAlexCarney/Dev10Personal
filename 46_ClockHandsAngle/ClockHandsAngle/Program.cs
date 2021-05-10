using System;

namespace ClockHandsAngle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculate the angle between hour hand and minute hand on the analog clock");
            string HourhandTime = Console.ReadLine();
            DateTime time = DateTime.Parse(HourhandTime);
            
            Console.WriteLine($"{AngleBetweenHands(time)}");

            DrawClock(DateTime.Now);
        }

        static void DrawClock(DateTime time) 
        {
            // draw clock here : P
            Console.WriteLine(@"  _______");
            Console.WriteLine(@" /  12   \");
            Console.WriteLine(@"|         |");
            Console.WriteLine(@"|         |");
            Console.WriteLine(@"|9       3|");
            Console.WriteLine(@"|         |");
            Console.WriteLine(@"|         |");
            Console.WriteLine(@" \___6___/");
        }

        //each minute adds 6 degrees to distance between hands
        //each hours adds 30 degrees between hands
        //absolute values need to be taken because when you get 7 degree distance decreases
        //assume that the minute hand only moves every minute
        static double AngleBetweenHands(DateTime time) 
        {
            double minuteHandAngle = (time.Minute * 6.0);
            double hourHandAngle = ((time.Hour%12) * 30.0) + (time.Minute * 6.0 / 60.0);

            return Math.Abs(minuteHandAngle - hourHandAngle);
        }
    }
}
