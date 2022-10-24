using PersonalNumberChecker.Interfaces.Validation;

namespace PersonalNumberChecker.Validation.Rules
{
    public class LengthRule : IValidationRule
    {
        public ValidationError ValidationError => ValidationError.InvalidLength;

        public bool IsRespected(string personalNumber)
        {
            return !string.IsNullOrEmpty(personalNumber) && personalNumber.Length == 10;
        }
    }
}
