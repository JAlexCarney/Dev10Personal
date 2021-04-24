using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using WeatherAlmanac.Core;
using WeatherAlmanac.DAL;
using WeatherAlmanac.BLL;

namespace WeatherAlmanac.UI
{
    public static class NinjectContainer
    {
        public static StandardKernel Kernel { get; private set; }

        public static void Configure(ApplicationMode mode, LoggerMode logMode) 
        {
            Kernel = new StandardKernel();

            if (mode == ApplicationMode.TEST)
            {
                Kernel.Bind<IRecordRepository>().To<MockRecordRepository>();
            }
            else 
            {
                Kernel.Bind<IRecordRepository>().To<FileRecordRepository>().WithConstructorArgument("filename", "almanac.csv");
            }

            switch (logMode) 
            {
                case LoggerMode.NULL:
                    Kernel.Bind<ILogger>().To<NullLogger>();
                    break;
                case LoggerMode.CONSOLE:
                    Kernel.Bind<ILogger>().To<ConsoleLogger>();
                    break;
                case LoggerMode.FILE:
                    Kernel.Bind<ILogger>().To<FileLogger>();
                    break;
            }

            Kernel.Bind<IRecordService>().To<RecordService>();
        }
    }
}
