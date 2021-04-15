using System;

namespace WeatherAlmanac.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherAlmanacController wc = new WeatherAlmanacController();
            wc.Run();
        }
    }
}
