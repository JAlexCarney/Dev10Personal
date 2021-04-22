using NUnit.Framework;

namespace StatefulUnitTestExercises.Tests
{
    public class SubmarineTest
    {
        Submarine submarine = new Submarine(100.0);

        [Test]
        public void shouldHaveCorrectDepthAfter3Dives()
        {
            submarine.Dive();
            submarine.Dive();
            submarine.Dive();
            Assert.AreEqual(9.0, submarine.DepthInMeters, 0.001);
        }

        [Test]
        public void shouldHaveCorrectPressureAfter3Dives()
        {
            submarine.Dive();
            submarine.Dive();
            submarine.Dive();
            // 1.0 at sea level plus 1.0 * 0.9
            Assert.AreEqual(1.9, submarine.PressureInAtmospheres, 0.001);
        }

        // 1. Create one or more tests to confirm `Dive` is working properly.
        // 2. Create a test to assert the submarine can't go deeper than the max depth.
        // (Be sure to use more than one max depth.)
        // 3. Create one or more tests to confirm `Surface` is working properly.
        // 4. Create a test to assert the submarine can't go above sea level.
        // (Depth can never be negative.)
        // 5. Create one or more tests to confirm `PressureInAtmospheres` is working properly.
    }
}