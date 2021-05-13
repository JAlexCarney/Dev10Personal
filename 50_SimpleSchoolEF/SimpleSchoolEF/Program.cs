using System;

namespace SimpleSchoolEF
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleSchoolController controller = new SimpleSchoolController(SimpleSchoolContext.GetDBContext());
            controller.Run();
        }
    }
}
