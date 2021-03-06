using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlmanac.Core;

namespace WeatherAlmanac.DAL
{
    public class FileRecordRepository : IRecordRepository
    {
        private string _fileName;
        private List<DateRecord> _records;
        private ILogger _logger;

        public FileRecordRepository(ILogger logger)
        {
            _fileName = @"almanac.csv";
            _records = new List<DateRecord>();
            _logger = logger;
            logger.Log("Created Repository");
            Load();
        }

        public FileRecordRepository(string fileName, ILogger logger)
        {
            _fileName = fileName;
            _records = new List<DateRecord>();
            _logger = logger;
            logger.Log("Created Repository");
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_fileName))
            {
                File.Create(_fileName).Close();
            }
            else
            {
                using (StreamReader sr = new StreamReader(_fileName))
                {
                    for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
                    {
                        /*
                        fields[0] DateTime Date
                        fields[1] decimal HighTemp
                        fields[2] decimal LowTemp
                        fields[3] decimal Humidity
                        fields[4] string Description
                        */
                        string[] fields = line.Split(',');
                        DateRecord record = new DateRecord();
                        record.Date = DateTime.Parse(fields[0]);
                        record.HighTemp = decimal.Parse(fields[1]);
                        record.LowTemp = decimal.Parse(fields[2]);
                        record.Humidity = decimal.Parse(fields[3]);
                        record.Description = fields[4];
                        _records.Add(record);
                    }
                }
            }
        }

        private void Save()
        {
            if (File.Exists(_fileName))
            {
                using (StreamWriter sw = new StreamWriter(_fileName))
                {
                    foreach (var record in _records)
                    {
                        sw.WriteLine($"{record.Date},{record.HighTemp},{record.LowTemp},{record.Humidity},{record.Description}");
                    }
                }
            }
            else 
            {
                throw new Exception("Failed to find file to write to.");
            }
        }

        private int FindIndex(DateTime date) 
        {
            for (int i = 0; i < _records.Count; i++) 
            {
                if (_records[i].Date.Day == date.Day
                    && _records[i].Date.Month == date.Month
                    && _records[i].Date.Year == date.Year)
                {
                    return i;
                }
            }
            return -1;
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            var result = new Result<DateRecord>();
            result.Message = "Successfully added record to database";
            result.Success = true;
            result.Data = record;
            _records.Add(record);
            try
            {
                Save();
            }
            catch (Exception e)
            {
                _logger.Log(e.Message);
                result.Success = false;
            }
            
            return result;
        }

        public Result<DateRecord> Edit(DateRecord oldRecord, DateRecord newRecord)
        {
            int index = -1;
            if (oldRecord != null) 
            {
                index = FindIndex(oldRecord.Date);
            }
            var result = new Result<DateRecord>();
            if (index == -1)
            {
                result.Message = "Could not find record to replace.";
                result.Success = false;
                result.Data = oldRecord;
            }
            else 
            {
                _records[index] = newRecord;
                result.Message = "Successfully replaced record in database";
                result.Success = true;
                result.Data = newRecord;
            }
            Save();
            return result;
        }

        public Result<List<DateRecord>> GetAll()
        {
            var result = new Result<List<DateRecord>>();
            if (_records == null || _records.Count == 0)
            {
                result.Message = "Can not retrieve data from an empty database";
                result.Success = false;
                result.Data = null;
            }
            else 
            {
                result.Message = "Successfully retrieved date records!";
                result.Success = true;
                result.Data = _records;
            }
            return result;
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            int index = FindIndex(date);
            var result = new Result<DateRecord>();
            if (index == -1)
            {
                result.Message = "Failed to find record in database";
                result.Success = false;
                result.Data = null;
            }
            else 
            {
                result.Data = _records[index];
                _records.RemoveAt(index);
                result.Message = "Successfully removed record from database";
                result.Success = true;
            }
            Save();
            return result;
        }
    }
}
