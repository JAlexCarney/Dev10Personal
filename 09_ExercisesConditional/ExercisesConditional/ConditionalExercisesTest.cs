using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestFixture]
    public class ConditionalExercisesTest
    {
        ConditionalExercises targetClass = new ConditionalExercises();

        [TestCase(12, 10, 2, true)]
        [TestCase(23, 10, 3, true)]
        [TestCase(17, 5, 1, false)]
        [TestCase(17, 0, 1, false)]
        /// <summary>
        /// Given a non-negative number, return true if the number is within range of a multiple of the target.
        /// </summary>
        public void AlmostNearTest(int num, int target, int range, bool expected)
        {
            Assert.AreEqual(expected, targetClass.AlmostNear(num, target, range));

        }

        [TestCase(true, 30, true, true)]
        [TestCase(false, 30, true, false)]
        [TestCase(true, 10, true, false)]
        [TestCase(true, 30, false, false)]
        /// <summary>
        /// Given we have power, paper and ink level is above 10 return true, when we have no power, always return false
        /// </summary>
        public void PrintDocumentTest(bool hasPaper, int inkLevel, bool hasPower, bool expected)
        {
            Assert.AreEqual(expected, targetClass.PrintDocument(hasPaper, inkLevel, hasPower));

        }

        [TestCase(true, 8, true)]
        [TestCase(false, 2, true)]
        [TestCase(false, 8, false)]
        /// <summary>
        /// Given it's the weekend we are allowed to party, however if it's not the weekend, we can only party between 0-7
        /// </summary>
        public void AllowedToPartyTest(bool isWeekend, int hour, bool expected)
        {
            Assert.AreEqual(expected, targetClass.AllowedToParty(isWeekend, hour));

        }

        [TestCase(300, false, false)]
        [TestCase(100, false, true)]
        [TestCase(210, true, true)]
        /// <summary>
        /// Given a non-negative number, return true if amount does not exceed a balance of 200. If over drafts are allowed, accept the balance withdrawl
        /// </summary>
        public void IsAllowedWidthdrawlTest(int amount, bool allowOverDraft, bool expected)
        {
            Assert.AreEqual(expected, targetClass.IsAllowedWidthdrawl(amount, allowOverDraft));
        }

        [TestCase(4, false)]
        [TestCase(8, true)]
        [TestCase(13, false)]
        /// <summary>
        /// Given a non-negative number, return true if roll is above 7 and below 12
        /// </summary>
        public void RollPassGoTest(int roll, bool expected)
        {
            Assert.AreEqual(expected, targetClass.RollPassGo(roll));
        }
    }
}
