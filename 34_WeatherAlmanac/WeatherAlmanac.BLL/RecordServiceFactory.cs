using WeatherAlmanac.Core;
using WeatherAlmanac.DAL;

namespace WeatherAlmanac.BLL
{
    public static class RecordServiceFactory
    {
        public static IRecordService GetRecordService(ApplicationMode mode, string LogMode = "null") 
        {
            if (mode == ApplicationMode.LIVE)
            {
                if (LogMode.ToLower() == "file")
                {
                    return new RecordService(new FileRecordRepository(new FileLogger("ErrorLog.txt")));
                }
                else if (LogMode.ToLower() == "console")
                {
                    return new RecordService(new FileRecordRepository(new ConsoleLogger()));
                }
                else 
                {
                    return new RecordService(new FileRecordRepository(new NullLogger()));
                }
                
            }
            else
            {
                return new RecordService(new MockRecordRepository());
            }
        }
    }
}
