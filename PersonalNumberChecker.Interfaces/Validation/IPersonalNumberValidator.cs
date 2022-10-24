using System.Collections.Generic;

namespace PersonalNumberChecker.Interfaces.Validation
{
    public enum ValidationError
    {
        InvalidLength,
        InvalidBirthDate,
        InvalidLastDigit,
        NotOnlyNumbers
    }

    public interface IPersonalNumberValidator
    {
        IEnumerable<ValidationError> Validate(string personalNumber);
    }
}
