using NUnit.Framework;
using PersonalNumberChecker.Validation.Rules;

namespace PersonalNumberChecker.Tests.Validation
{
    public class OnlyDigitsRuleTests
    {
        private OnlyDigitsRule rule;

        [SetUp]
        public void Init()
        {
            //Arrange
            this.rule = new OnlyDigitsRule();
        }

        [Test]
        public void RuleIsNotRespectedWhenNotAllAreDigits()
        {
            //Act
            bool isRespected = rule.IsRespected("aaabb44456");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsNotRespectedWnenNegativeDigitExists()
        {
            //Act
            bool isRespected = rule.IsRespected("-123-54");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsRespectedWhenAllAreDigits()
        {
            //Act
            bool isRespected = rule.IsRespected("12345");

            //Assert
            Assert.True(isRespected);
        }

    }
}

