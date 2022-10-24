using Moq;
using NUnit.Framework;
using PersonalNumberChecker.Interfaces.Validation;
using PersonalNumberChecker.Validation.Validators;
using System.Collections.Generic;
using System.Linq;

namespace PersonalNumberChecker.Tests.Validation
{
    public class PersonalNumberValidatorTests
    {
        [Test]
        public void ValidateReturnsErrorWhenAtLeastOneRuleIsNotRespected()
        {
            //Arrange
            Mock<IValidationRule> ruleOne = new Mock<IValidationRule>();
            ruleOne.Setup(r => r.IsRespected(It.IsAny<string>())).Returns(true);

            Mock<IValidationRule> ruleTwo = new Mock<IValidationRule>();
            ruleTwo.Setup(r => r.IsRespected(It.IsAny<string>())).Returns(false);

            var rules = new List<IValidationRule> { ruleOne.Object, ruleTwo.Object };
            PersonalNumberValidator validator = new PersonalNumberValidator(rules);

            //Act
            var errors = validator.Validate("abc");

            //Assert
            Assert.True(errors.Count() > 0);
        }

        [Test]
        public void ValidateReturnsNoErrorsWhenAllRulesAreRespected()
        {
            //Arrange
            Mock<IValidationRule> ruleOne = new Mock<IValidationRule>();
            ruleOne.Setup(r => r.IsRespected(It.IsAny<string>())).Returns(true);

            Mock<IValidationRule> ruleTwo = new Mock<IValidationRule>();
            ruleTwo.Setup(r => r.IsRespected(It.IsAny<string>())).Returns(true);

            var rules = new List<IValidationRule> { ruleOne.Object, ruleTwo.Object };
            PersonalNumberValidator validator = new PersonalNumberValidator(rules);

            //Act
            var errors = validator.Validate("abc");

            //Assert
            Assert.True(errors.Count() == 0);
        }
    }
}
