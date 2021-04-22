using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessUnitTestExercises
{
    class StringMethods
    {
        private static string[] _daysOfWeek = new string[] { "mon", "tues", "weds", "thurs", "fri", "sat", "sun" };
        
        /// <summary>
        /// return true if the parameters starts with a day of week abbreviation:
        /// Mon, Tues, Weds, Thurs, Fri, Sat, Sun
        /// or false if it doesn't
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StartsWithDayOfWeek(string value) 
        {
            string loweredValue = value.ToLower();

            foreach (string day in _daysOfWeek) 
            {
                if (loweredValue.StartsWith(day)) 
                {
                    return true;
                }
            }

            return false;
        }
    }
}
