using NUnit.Framework;
using StatelessUnitTestExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessUnitTestExercises.Tests
{
    class Exercise03Test
    {
        [Test]
        public void ShouldIdentifyIfStringHasAllVowelsOrNot()
        {
            // Arrange
            string test1 = "This sentence has all the vowels that you could ever want!";
            string test2 = "This sentence does not!";

            // Act
            bool test1Result = Exercise03.HasAllVowels(test1);
            bool test2Result = Exercise03.HasAllVowels(test2);

            // Assert
            Assert.AreEqual(test1Result, true);
            Assert.AreEqual(test2Result, false);
        }
    }
}
