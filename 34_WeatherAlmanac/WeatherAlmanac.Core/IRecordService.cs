using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAlmanac.Core
{
    public interface IRecordService
    {
        Result<List<DateRecord>> LoadRange(DateTime start, DateTime end);
        Result<DateRecord> Get(DateTime date);
        Result<DateRecord> Add(DateRecord record);
        Result<DateRecord> Remove(DateTime date);
        Result<DateRecord> Edit(DateTime date, DateRecord dateRecord);
    }
}
