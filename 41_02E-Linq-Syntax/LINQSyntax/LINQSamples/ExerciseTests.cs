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
        public void ConversionsToArray_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.ConversionsToArray();

            // Assert
            Assert.IsTrue(result is Person[]);
        }

        [Test]
        public void ConversionsToDictionary_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.ConversionsToDictionary();

            // Assert
            Assert.IsTrue(result is Dictionary<int, Person>);
        }

        [Test]
        public void ConversionsToList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var exercise = new Exercise();

            // Act
            var result = exercise.ConversionsToList();

            // Assert
            Assert.IsTrue(result is List<Person>);
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
    }
}
