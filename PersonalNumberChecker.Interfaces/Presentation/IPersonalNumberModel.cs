using System;

namespace PersonalNumberChecker.Interfaces.Presentation
{
    public enum Gender
    {
        Male,
        Female
    };

    public interface IPersonalNumberModel
    {
        DateTime BirthDate { get; }

        Gender Gender { get; }

        bool IsValid { get; }
    }
}
