using System;

namespace SimpleSchoolRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildingService service = new BuildingService(@"http://localhost:50271/");
            service.GetRoomsByBuilding();
        }
    }
}
