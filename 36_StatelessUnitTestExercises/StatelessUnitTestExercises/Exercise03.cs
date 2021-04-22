namespace StatelessUnitTestExercises
{
    public class Exercise03
    {
        // 1. Read the HasAllVowels docs.
        // 2. Complete the HasAllVowels method.
        // 3. Create tests to fully test HasAllVowels and confirm that it's 100% correct.

        /// <summary>
        /// Determines if a string contains *all* English vowels: a, e, i, o, and u.
        /// Both uppercase and lowercase vowels are allowed.
        /// The `null` value should return false.
        /// </summary>
        /// <param name="value">the string to test</param>
        /// <returns>true if the value contains all 5 vowels, false if it doesn't</returns>
        public static bool HasAllVowels(string value)
        {
            string vowels = "aeiou";

            foreach (char vowel in vowels) 
            {
                if (!value.Contains(vowel)) 
                {
                    return false;
                }
            }

            return true;
        }
    }
}
