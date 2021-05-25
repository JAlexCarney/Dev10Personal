using System;

namespace WarmUpMay20
{
    public static class Decoder
    {
        public static string Decode(string code)
        {
            string decoded = "";
            foreach  (char digit in code)
            {
                try
                {
                    decoded += DecodeDigit(int.Parse(digit.ToString()));
                }
                catch
                {
                    return "";
                }
            }
            return decoded;
        }

        private static int DecodeDigit(int digit)
        {
            if (digit == 0) return 5;
            if (digit == 5) return 0;

            return 10 - digit;
        }
    }
}