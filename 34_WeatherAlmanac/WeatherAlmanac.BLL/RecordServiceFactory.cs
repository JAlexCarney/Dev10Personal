using WeatherAlmanac.Core;
using WeatherAlmanac.DAL;

namespace WeatherAlmanac.BLL
{
    public static class RecordServiceFactory
    {
        public static IRecordService GetRecordService(ApplicationMode mode) 
        {
            if (mode == ApplicationMode.LIVE)
            {
                return new RecordService(new FileRecordRepository());
            }
            else
            {
                return new RecordService(new MockRecordRepository());
            }
        }
    }
}
