using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherAlmanac.Core
{
    public class FileLogger : ILogger
    {
        private string _filePath;

        public FileLogger(string filePath) 
        {
            _filePath = filePath;
            if (!File.Exists(filePath)) 
            {
                File.Create(_filePath).Close();
            }
        }

        public void Log(string message) 
        {
            File.AppendAllText(_filePath, $"{DateTime.Now},{message}\n");
        }
    }
}
