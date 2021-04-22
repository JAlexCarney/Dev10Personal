using NUnit.Framework;
using StatelessUnitTestExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessUnitTestExercises.Tests
{
    class Exercise07Test
    {
        [Test]
        public void ShouldReveaseStringArrayWithoutAlteringArgument() 
        {
            // Arrange
            string[] testArray1 = new string[] { "one", "two", "three" };
            string[] testArray2 = new string[] { "one", "two", "three" };

            // Act
            string[] outPutArray = Exercise07.reverse(testArray1);

            // Assert
            Assert.AreEqual(testArray1[0], testArray2[0]);
            Assert.AreEqual(testArray1[1], testArray2[1]);
            Assert.AreEqual(testArray1[2], testArray2[2]);
            
            Assert.AreEqual(outPutArray[0], testArray1[2]);
            Assert.AreEqual(outPutArray[1], testArray1[1]);
            Assert.AreEqual(outPutArray[2], testArray1[0]);
        }
    }
}
