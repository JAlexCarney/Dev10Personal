using System;
using System.Collections.Generic;
using WeatherAlmanac.Core;

namespace WeatherAlmanac.BLL
{
    public class RecordService : IRecordService
    {
        private IRecordRepository _repo;

        public RecordService(IRecordRepository implementation) 
        {
            _repo = implementation;
        }

        public Result<DateRecord> Add(DateRecord record) => _repo.Add(record); // TODO: Add check for duplicate entry

        public Result<DateRecord> Edit(DateTime date, DateRecord newRecord) => _repo.Edit(Get(date).Data, newRecord);

        public Result<DateRecord> Get(DateTime date) 
        {
            var records = _repo.GetAll();
            var result = new Result<DateRecord>();
            for (int i = 0; i < records.Data.Count; i++)
            {
                if (records.Data[i].Date.Day == date.Day
                    && records.Data[i].Date.Month == date.Month
                    && records.Data[i].Date.Year == date.Year)
                {
                    result.Data = records.Data[i];
                    result.Success = true;
                    result.Message = "Successfully Retrived record";
                    return result;
                }
            }
            result.Data = null;
            result.Success = false;
            result.Message = "Failed to find record in database";
            return result;
        }

        public Result<List<DateRecord>> LoadRange(DateTime start, DateTime end)
        {
            var records = _repo.GetAll();
            var result = new Result<List<DateRecord>>
            {
                Data = new List<DateRecord>()
            };
            foreach (var record in records.Data) 
            {
                if (record.Date.Subtract(start).Ticks >= 0 && end.Subtract(record.Date).Ticks >= 0) 
                {
                    result.Data.Add(record);
                }
            }
            if (result.Data.Count == 0)
            {
                result.Success = false;
                result.Message = "Failed to find any records in range.";
            }
            else 
            {
                result.Success = true;
                result.Message = "Read Files From Database.";
            }
            return result;
        }

        public Result<DateRecord> Remove(DateTime date) => _repo.Remove(date);
    }
}
