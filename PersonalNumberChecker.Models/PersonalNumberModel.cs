using PersonalNumberChecker.Interfaces.Presentation;
using System;

namespace PersonalNumberChecker.Models
{
    public class PersonalNumberModel : IPersonalNumberModel
    {
        public PersonalNumberModel(bool isValid)
        {
            this.IsValid = isValid;
        }

        public PersonalNumberModel(DateTime date, Gender gender, bool isValid) : this(isValid)
        {
            this.BirthDate = date.Date;
            this.Gender = gender;
        }

        public DateTime BirthDate { get; }

        public Gender Gender { get; }

        public bool IsValid { get; }
    }
}
