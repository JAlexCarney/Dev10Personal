namespace StatelessUnitTestExercises
{
    public class Exercise05
    {
        // 1. Read the IsWithinFiveOfAHundred docs.
        // 2. Implement IsWithinFiveOfAHundred.
        // 3. Create tests for IsWithinFiveOfAHundred and confirm that it is correct.

        /// <summary>
        /// Determines if a value is within 5 of any number evenly divisible by 100.
        /// Examples
        /// -105 to -95: true
        /// -94 to -6: false
        /// -5 to 5: true
        /// 6 to 94: false
        /// 95 to 105: true
        /// 106 to 194: false
        /// 195 to 205: true
        /// 206 to 294: false
        /// ...continues in both the positive and negative directions...
        /// </summary>
        /// <param name="value">the number to test</param>
        /// <returns>true if value is within 5 of a number evenly divisible by 100, false if not.</returns>
        public static bool IsWithinFiveOfAHundred(int value)
        {
            for (int i = value - 5; i <= value + 5; i++) 
            {
                if (i % 100 == 0) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
