using PersonalNumberChecker.Interfaces.Validation;
using System.Text.RegularExpressions;

namespace PersonalNumberChecker.Validation.Rules
{
    public class OnlyDigitsRule : IValidationRule
    {
        public ValidationError ValidationError => ValidationError.NotOnlyNumbers;

        public bool IsRespected(string personalNumber)
        {
            Regex validateNumbersRegex = new Regex("^\\d+$");
            return validateNumbersRegex.IsMatch(personalNumber);
        }
    }
}
