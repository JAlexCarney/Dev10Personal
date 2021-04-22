using NUnit.Framework;

namespace StatelessUnitTestExercises.Tests
{
    public class Exercise04Test
    {
        [Test]
        public void CalculateTotalCost()
        {
            Exercise04 instance = new Exercise04();

            // doubles are notoriously hard to test because they use floating-point rounding.
            // The third argument in `Assert.AreEqual` is a delta. It represents the margin of error for equality.
            // As long as the expected and actual differ by less than the delta, the test passes.
            Assert.AreEqual(1.25, instance.CalculateTotalCost(0.25, 5), 0.001);
            Assert.AreEqual(99.06, instance.CalculateTotalCost(1.27, 100), 0.001);
        }
    }
}