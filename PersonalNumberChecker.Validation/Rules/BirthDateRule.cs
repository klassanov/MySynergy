using PersonalNumberChecker.Extensions;
using PersonalNumberChecker.Interfaces.Validation;
using System;
using System.Globalization;

namespace PersonalNumberChecker.Validation.Rules
{
    public class BirthDateRule : IValidationRule
    {
        public ValidationError ValidationError => ValidationError.InvalidBirthDate;

        public bool IsRespected(string personalNumber)
        {
            return DateTime.TryParseExact(personalNumber.ToBirthdayDateString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
