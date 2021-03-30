using NUnit.Framework;
using System;

namespace Exercises.Tests
{
    [TestFixture]
    public class StringExercisesTest
    {
        StringExercises target = new StringExercises();
        /// <summary>
        /// Given a string, return a "rotated left 2" version where the first 2 chars are moved to the end.
        /// The string length will be at least 2.
        /// </summary>
        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void Left2Test(string input, string expected)
        {
            Assert.AreEqual(target.Left2(input), expected);
        }
        /// <summary>
        /// Given a string, return a formatted string with the following format. "Hello world, my name is {input}!"
        /// </summary>
        [TestCase("Bob","Hello world, my name is Bob!")]
        [TestCase("","Hello world, my name is !")]
        public void StandardGreetingTest(string input, string expected)
        {
            Assert.AreEqual(target.StandardGreeting(input), expected);

        }
        /// <summary>
        /// Given a string, return a string with words without vowels.
        /// </summary>
        [TestCase("Hello","Hll")]
        [TestCase("GoodBye", "GdB")]
        [TestCase("Euouae", "")]

        public void RemoveVowelsTest(string input, string expected)
        {
            Assert.AreEqual(target.RemoveVowels(input), expected);

        }
        /// <summary>
        /// Given 2 strings, a and b, return a string of the form long + short + long,
        /// with the longer string on the outside and the shorter string on the inside.
        /// The strings will not be the same length, but they may be empty (length 0).
        /// </summary>
        [TestCase("Hello", "hi", "HellohiHello")]
        [TestCase("hi", "Hello", "HellohiHello")]
        [TestCase("aaa", "b", "aaabaaa")]
        public void HiddenMessageTest(string inputA, string inputB, string expected)
        {
            Assert.AreEqual(target.HiddenMessage(inputA, inputB), expected);

        }

        /// <summary>
        /// Given a string, and a number, return a string from the x number of the end.
        /// So "Candy", 4, returns "andy". X must be less then the length of the string.
        /// String length must be greater than 1
        /// </summary>
        [TestCase("Candy", 4, "andy")]
        [TestCase("and", 2, "nd")]
        [TestCase("coding", 3, "ing")]
        public void SectionStringTest(string input, int length, string expected)
        {
            Assert.AreEqual(target.SectionString(input, length), expected);

        }
    }
}
