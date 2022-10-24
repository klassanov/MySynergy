using PersonalNumberChecker.Interfaces.Validation;
using System;
using System.Collections.Generic;

namespace PersonalNumberChecker.Validation.Rules
{
    public class LastDigitRule : IValidationRule
    {
        private static readonly Dictionary<int, int> coefficients = new Dictionary<int, int>()
        {
                {0,2},
                {1,4},
                {2,8},
                {3,5},
                {4,10},
                {5,9},
                {6,7},
                {7,3},
                {8,6}
        };

        public ValidationError ValidationError => ValidationError.InvalidLastDigit;

        public bool IsRespected(string personalNumber)
        {
            if(string.IsNullOrEmpty(personalNumber) || personalNumber.Length != 10)
            {
                throw new ArgumentException("Personal number wrong format");
            }

            int expectedLastDigit = this.GetExpectedLastDigit(personalNumber);
            return !string.IsNullOrEmpty(personalNumber) && (int)char.GetNumericValue(personalNumber[personalNumber.Length - 1]) == expectedLastDigit;
        }

        private int GetExpectedLastDigit(string personalNumber)
        {
            int result = 0;
            for (int i = 0; i<personalNumber.Length-1; i++)
            {
                int digit = (int)char.GetNumericValue(personalNumber[i]);
                result += digit * coefficients[i];
            }

            return (result % 11) % 10;
        }
    }
}
