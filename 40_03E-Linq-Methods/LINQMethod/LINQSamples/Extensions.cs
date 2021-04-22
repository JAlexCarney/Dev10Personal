using System;

namespace LINQSamples
{
    public static class Extensions
    {
        public static int GetAge(this DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            if (today.Month < dateOfBirth.Month ||
                ((today.Month == dateOfBirth.Month) && (today.Day < dateOfBirth.Day)))
            {
                age--;
            }

            return age;
        }
    }
}