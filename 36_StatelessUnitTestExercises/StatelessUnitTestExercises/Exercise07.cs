namespace StatelessUnitTestExercises
{
    public class Exercise07
    {

        // 1. Read the Reverse docs.
        // 2. Implement Reverse.
        // 3. Create tests for Reverse and confirm that it is correct.
        // It's especially important to ensure the argument is not altered.
        // The method should return a new array. Confirm with testing.

        /// <summary>
        /// Reverses the order of elements in an array argument and returns them in a new array.
        /// It does not alter the existing array.
        /// </summary>
        /// <param name="values">the array to reverse</param>
        /// <returns>a new array with elements in reverse order.</returns>
        public static string[] reverse(string[] values)
        {
            string[] reversed = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                reversed[i] = values[values.Length - 1 - i];
            }

            return reversed;
        }
    }
}
