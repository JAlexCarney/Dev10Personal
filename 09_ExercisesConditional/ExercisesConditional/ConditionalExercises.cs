using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class ConditionalExercises
    {

        /// <summary>
        /// Given a non-negative number, return true if the number is within range of a multiple of the target.
        // Given 12, 10, and  2 return true
        // Given 23, 10, and  3 return true
        // Given 17, 5, and  1 return false)]
        // Given 17, 0, and  1 return false)]
        /// </summary>
        public bool AlmostNear(int num, int target, int range)
        {
            throw new NotImplementedException();

        }


        /// <summary>
        /// Given we have power, paper and ink level is above 10 return true, when we have no power, always return false
        // Given true, 30, and  true return true)]
        // Given false, 30, and  true return false)]
        // Given true, 10, and  true return false)]
        // Given true, 30, and  false return false)]
        /// </summary>
        public bool PrintDocument(bool hasPaper, int inkLevel, bool hasPower)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Given it's the weekend we are allowed to party, however if it's not the weekend, we can only party between 0-7
        // Given true, and  8 return true)]
        // Given false, and  2 return true)]
        // Given false, and  8 return false)]
        /// </summary>
        public bool AllowedToParty(bool isWeekend, int hour)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Given a non-negative number, return true if amount does not exceed a balance of 200. If over drafts are allowed, accept the balance withdrawl
        // Given 300, and false return false)]
        // Given 100, and  false return true)]
        // Given 210, and  true return true)]
        /// </summary>
        public bool IsAllowedWidthdrawl(int amount, bool allowOverDraft)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Given a non-negative number, return true if roll is above 7 and below 12
        // Given 4 return false)]
        // Given 8 return true)]
        // Given 13 return false)]
        /// </summary>
        public bool RollPassGo(int roll)
        {
            throw new NotImplementedException();
        }
    }
}
