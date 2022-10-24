using PersonalNumberChecker.Extensions;
using PersonalNumberChecker.Interfaces.Parsing;
using PersonalNumberChecker.Interfaces.Presentation;
using PersonalNumberChecker.Interfaces.Validation;
using PersonalNumberChecker.Models;
using System;
using System.Globalization;
using System.Linq;

namespace PersonalNumberChecker.Parsing
{
    public class PersonalNumberParser : IPersonalNumberParser
    {
        private readonly IPersonalNumberValidator validator;

        public PersonalNumberParser(IPersonalNumberValidator validator)
        {
            this.validator = validator;
        }

        public IPersonalNumberModel ParsePersonalNumber(string personalNumber)
        {
            var validationErrors = this.validator.Validate(personalNumber);
            if (validationErrors.Count() > 0)
            {
                return new PersonalNumberModel(false);
            }

            var gender = this.GetGender(personalNumber);
            var birthDate = this.GetBirthDate(personalNumber);

            return new PersonalNumberModel(birthDate, gender, true);
        }

        private Gender GetGender(string personalNumber)
        {
            var genderDigit = (int)char.GetNumericValue(personalNumber[8]);
            return genderDigit % 2 == 0 ? Gender.Male : Gender.Female;
        }

        private DateTime GetBirthDate(string personalNumber)
        {
            return DateTime.ParseExact(personalNumber.ToBirthdayDateString(), "yyyyMMdd", CultureInfo.InvariantCulture);
        }
    }
}
