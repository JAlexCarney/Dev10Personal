using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAlmanac.Core
{
    public interface IRecordRepository
    {
        Result<List<DateRecord>> GetAll();
        Result<DateRecord> Add(DateRecord record);
        Result<DateRecord> Remove(DateTime date);
        Result<DateRecord> Edit(DateRecord oldRecord, DateRecord newRecord);
    }
}
