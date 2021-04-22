using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAlmanac.Core;
using WeatherAlmanac.DAL;
using System.IO;
using System;

namespace WeatherAlmanac.Test
{
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void ShouldLogErrorIfFileIsLostDurringExicution()
        {
            // Arrange
            var repo = new FileRecordRepository("TestAlmanac.csv", new FileLogger("TestErrorLog.txt"));
            var testRecord = new DateRecord
            {
                Date = DateTime.Now,
                HighTemp = 100,
                LowTemp = 20,
                Humidity = 10,
                Description = "Normal Day"
            };

            // Act
            File.Delete("TestAlmanac.csv");
            var result = repo.Add(testRecord);

            // Assert
            Assert.IsTrue(File.Exists("TestErrorLog.txt"));
            Assert.AreEqual(false, result.Success);

            // Clean Up
            File.Delete("TestErrorLog.txt");
        }
    }
}
