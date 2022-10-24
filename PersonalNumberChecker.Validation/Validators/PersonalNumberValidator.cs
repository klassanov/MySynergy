using PersonalNumberChecker.Interfaces.Validation;
using System.Collections.Generic;

namespace PersonalNumberChecker.Validation.Validators
{
    public class PersonalNumberValidator : IPersonalNumberValidator
    {
        private readonly List<ValidationError> validationErrors;
        private readonly IEnumerable<IValidationRule> validationRules;

        public PersonalNumberValidator(IEnumerable<IValidationRule> validationRules)
        {
            this.validationRules = validationRules;
            this.validationErrors = new List<ValidationError>();
        }

        public IEnumerable<ValidationError> Validate(string personalNumber)
        {
            foreach (var rule in validationRules)
            {
                if (!rule.IsRespected(personalNumber))
                {
                    validationErrors.Add(rule.ValidationError);
                    break;
                }
            }

            return this.validationErrors;
        }
    }
}
