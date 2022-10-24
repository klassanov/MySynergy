namespace PersonalNumberChecker.Extensions
{
    public static class StringExtensions
    {
        public static string ToBirthdayDateString(this string personalNumber)
        {
            string birthDateString;
            int monthNumber = int.Parse(personalNumber.Substring(2, 2));

            //Born before 2000
            if (monthNumber <= 12 && monthNumber >= 1)
            {
                birthDateString = $"19{personalNumber.Substring(0, 6)}";
            }

            //Born after 2000
            else
            {
                monthNumber -= 40;
                string monthString = monthNumber.ToString().PadLeft(2, '0');
                birthDateString = $"20{personalNumber.Substring(0, 2)}{monthString}{personalNumber.Substring(4, 2)}";
            }

            return birthDateString;
        }
    }
}
