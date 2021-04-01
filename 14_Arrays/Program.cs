using System;

namespace _14_Arrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // MERGE
            int[] one = MakeRandomAscendingArray();
            int[] two = MakeRandomAscendingArray();

            // MakeRandomAscendingArray creates a random array with a capacity between 50 and 150.
            // Its elements are guaranteed to be sorted ascending.
            // 1. Create a new int[] with capacity for all elements from `one` and `two`.
            int[] oneAndTwo = new int[one.Length + two.Length];
            // 2. "Merge" elements from `one` and `two` into the new array so that its values are sorted.
            int oneIndex = 0;
            int twoIndex = 0;
            for (int i = 0; i < oneAndTwo.Length; i++) 
            {
                if (one[oneIndex] < two[twoIndex])
                {
                    oneAndTwo[i] = one[oneIndex];
                    if (oneIndex != one.Length - 1)
                    {
                        oneIndex++;
                    }
                }
                else if (two[twoIndex] <= one[oneIndex]) 
                {
                    oneAndTwo[i] = two[twoIndex];
                    if (twoIndex != two.Length - 1) 
                    {
                        twoIndex++;
                    }
                }
            }

            foreach (int num in oneAndTwo) 
            {
                Console.WriteLine(num);
            }


            /* Pseudocode:
            Create an integer index for `one`, `two`, and the result array, all starting at 0.
            Loop resultIndex from 0 to result.length - 1:
              if one[oneIndex] is less than two[twoIndex], add it to the result and increment oneIndex.
              if two[twoIndex] is less than one[oneIndex], add it to the result and increment twoIndex.
              determine how to settle ties
              if oneIndex >= one.length, there are no `one` elements remaining so use elements from two
              if twoIndex >= two.length, there are no `two` elements remaining so use elements from one
             */
        }

        public static int[] MakeRandomAscendingArray()
        {
            Random random = new Random();
            int[] result = new int[random.Next(100) + 50];
            int current = random.Next(11);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = current;
                current += random.Next(4);
            }
            return result;
        }
    }
}
