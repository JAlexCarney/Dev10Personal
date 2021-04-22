namespace StatelessUnitTestExercises
{
    public class Exercise06
    {
        // 1. Read the CapitalizeAll docs.
        // 2. Implement CapitalizeAll.
        // 3. Implement suggestions in Exercise06Test.
        // 4. Confirm implementation correctness by running tests.
        // 5. Stretch Goal: instead of capitalizing the first character of each element, capitalize the first character
        // of each word in each element.      

        /// <summary>
        /// Capitalizes the first character of each element in a string[]
        /// and returns the result in a new array.
        /// A null argument should return null.
        /// An empty array should return a new empty array.
        /// Null or empty array elements should be ignored.
        /// </summary>
        /// <param name="values">an array containing elements to capitalize.</param>
        /// <returns>a new string[] with each element capitalized.</returns>
        public string[] CapitalizeAll(string[] values)
        {
            string[] newValues = new string[values.Length];
            for (int i = 0; i < values.Length; i++) 
            {
                if (!string.IsNullOrEmpty(values[0])) 
                {
                    if (values[0].Length > 0)
                    {
                        newValues[i] = values[i][0].ToString().ToUpper() + values[0].Substring(1);
                    }
                    else
                    {
                        newValues[i] = values[i].ToUpper();
                    }
                }
            }
            return newValues;
        }
    }
}
