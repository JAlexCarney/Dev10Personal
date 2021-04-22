using System.Collections.Generic;
using System.Linq;
using LINQSamples;
using LINQSamples.Core;
using NUnit.Framework;

namespace LINQSamples
{
    [TestFixture]
    public class ExerciseTests
    {
        [Test]
        public void People_taller_than_60_inches()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.WhereQuery();

            // Assert
            Assert.AreEqual(289, result.Count);
        }

        [Test]
        public void OrderingData()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.OrderingData();

            // Assert
            Assert.AreEqual("Wally", result.FirstOrDefault().FirstName);
        }

        [Test]
        public void Group_Patients_By_State()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.Grouping();

            // Assert
            Assert.AreEqual(43, result.Count());
            Assert.AreEqual("Georgia", result.FirstOrDefault().Key);
            Assert.AreEqual("Hazel", result.FirstOrDefault().FirstOrDefault().FirstName);
        }

        [Test]
        public void Select_Patient_Summary()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.GetPatientSummary();

            // Assert
            Assert.AreEqual(1000, result.Count);
            Assert.AreEqual("Randolf Hele (Pittsburgh , Pennsylvania): 28", result.FirstOrDefault());
        }

        [Test]
        public void AllPatientsAboveTwentyInchesTest()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.AllPatientsAboveTwentyInches();

            // Assert
            Assert.IsFalse(result);

        }
        [Test]
        public void AnyOhioians()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.AnyOhioians();

            // Assert
            Assert.IsTrue(result);

        }
        [TestCase("Ohio")]
        public void LiveInSelectStates(string state)
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.LiveInSelectStates(state);

            // Assert
            Assert.IsTrue(result);

        }
        [Test]
        public void AverageHeightTest()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.AverageHeight();

            // Assert
            Assert.AreEqual(42.22525m, result);
        }
        [Test]
        public void MaxHeightTest()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.MaxHeight();

            // Assert
            Assert.AreEqual(83.95m, result);
        }
        [Test]
        public void MinHeightTest()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.MinHeight();

            // Assert
            Assert.AreEqual(1.17m, result);
        }
        [Test]
        public void CountTotalOverOneHundredPoundTests()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.CountTotalOverOneHundredPounds();

            // Assert
            Assert.AreEqual(957, result);
        }
    }
}
