using NUnit.Framework;
using WarmUpWeek9Day2;

namespace WarnUpWeek9Day2.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //Assert.AreEqual("Draw", )
        }

        [TestCase("a", "c", "Winner: Two(a)")]
        [TestCase("abc", "ab", "Winner: One(c)")]
        [TestCase("boy", "girl", "Winner: Two(fl)")]
        [TestCase("a", "a", "Draw")]
        [TestCase("ab", "ab", "Draw")]
        [TestCase("dog", "cat", "Draw")]
        public void ShouldFight(string s1, string s2, string expected)
        {
            Assert.AreEqual(expected, Battle.Combat(s1, s2));
        }

        [TestCase(1, 'a')]
        [TestCase(26, 'z')]
        [TestCase(27, 'A')]
        [TestCase(52, 'Z')]
        public void ShouldHealthToChar(int data, char expected) 
        {
            Assert.AreEqual(expected, Battle.HealthToChar(data));
        }

        [TestCase('a', 1)]
        [TestCase('z', 26)]
        [TestCase('A', 27)]
        [TestCase('Z', 52)]
        public void ShouldCharToHealth(char data, int expected)
        {
            Assert.AreEqual(expected, Battle.CharToHealth(data));
        }
    }
}