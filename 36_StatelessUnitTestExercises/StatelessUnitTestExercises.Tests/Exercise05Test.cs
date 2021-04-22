using NUnit.Framework;
using StatelessUnitTestExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessUnitTestExercises.Tests
{
    class Exercise05Test
    {
        [Test]
        public void ShouldReturnTrueForValuesNearMultiplesOfOneHundred() 
        {
            Assert.That(!Exercise05.IsWithinFiveOfAHundred(-106));
            Assert.That(!Exercise05.IsWithinFiveOfAHundred(37));
            Assert.That(!Exercise05.IsWithinFiveOfAHundred(-94));
            Assert.That(Exercise05.IsWithinFiveOfAHundred(-105));
            Assert.That(Exercise05.IsWithinFiveOfAHundred(95));
        }
    }
}
