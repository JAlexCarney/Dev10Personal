using NUnit.Framework;

namespace StatelessUnitTestExercises.Tests
{
    public class Exercise01Test
    {
        [Test]
        public void ShouldAdd()
        {
            Assert.AreEqual(2, Exercise01.Add(1, 1));
            Assert.AreEqual(0, Exercise01.Add(112, -112));
            Assert.AreEqual(-256, Exercise01.Add(-206, -50));
            Assert.AreEqual(256, Exercise01.Add(150, 106));
            Assert.AreEqual(17, Exercise01.Add(10, 7));
            Assert.AreEqual(-5, Exercise01.Add(300, -305));
        }

        [Test]
        public void ShouldSubtract()
        {
            Assert.AreEqual(0, Exercise01.Subtract(10, 10));
            Assert.AreEqual(5, Exercise01.Subtract(10, 5));
            Assert.AreEqual(-15, Exercise01.Subtract(10, 25));
            Assert.AreEqual(100000, Exercise01.Subtract(100001, 1));
            Assert.AreEqual(-200, Exercise01.Subtract(50, 250));
            Assert.AreEqual(13, Exercise01.Subtract(40, 27));
        }
    }
}