using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core;

namespace WeatherAlmanac.DAL
{
    public class MockRecordRepository : IRecordRepository
    {
        private List<DateRecord> _records;

        public MockRecordRepository() 
        {
        
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            throw new NotImplementedException();
        }

        public Result<DateRecord> Edit(DateRecord oldRecord, DateRecord newRecord)
        {
            throw new NotImplementedException();
        }

        public Result<List<DateRecord>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
