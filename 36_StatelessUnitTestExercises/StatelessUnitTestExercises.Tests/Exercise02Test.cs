using NUnit.Framework;

namespace StatelessUnitTestExercises.Tests
{
    public class Exercise02Test
    {
        [Test]
        public void SurroundWithTags()
        {
            Assert.AreEqual("<b>a</b>", Exercise02.SurroundWithTag("a", "b"));
            Assert.AreEqual("splendid", Exercise02.SurroundWithTag("splendid", null));
        }
    }
}