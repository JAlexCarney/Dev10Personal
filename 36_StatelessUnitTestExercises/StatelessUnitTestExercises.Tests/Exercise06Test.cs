using NUnit.Framework;

namespace StatelessUnitTestExercises.Tests
{
    public class Exercise06Test
    {

        Exercise06 instance = new Exercise06();

        // Suggested test additions:
        // ShouldBeNullForNullArg
        // ShouldCapitalizeMultipleElements (several scenarios)
        // ShouldIgnoreNullElements
        // ShouldIgnoreEmptyElements

        [Test]
        public void ShouldCapitalizeOneElement()
        {
            string[] values = { "lower" };
            string[] expected = { "Lower" };
            string[] actual = instance.CapitalizeAll(values);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldBeEmptyForEmptyArg()
        {
            Assert.AreEqual(new string[0], instance.CapitalizeAll(new string[0]));
        }
    }
}