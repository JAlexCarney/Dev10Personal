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

        public static void Configure(ApplicationMode mode) 
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

            Kernel.Bind<IRecordService>().To<RecordService>();
        }
    }
}
