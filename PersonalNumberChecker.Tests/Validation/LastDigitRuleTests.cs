using NUnit.Framework;
using PersonalNumberChecker.Validation.Rules;
using System;

namespace PersonalNumberChecker.Tests.Validation
{
    public class LastDigitRuleTests
    {
        private LastDigitRule rule;

        [SetUp]
        public void Init()
        {
            //Arrange
            this.rule = new LastDigitRule();
        }

        [Test]
        public void RuleIsNotRespectedWhenLastDigitIsIncorrect()
        {
            //Act
            bool isRespected = rule.IsRespected("0347059193");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsRespectedWhenLastDigitIsCorrect()
        {
            //Act
            bool isRespected = rule.IsRespected("0347059192");

            //Assert
            Assert.True(isRespected);
        }

        [Test]
        public void ThrowsArgumentExceptionWhenLengthIsNotTen()
        {
            Assert.Throws<ArgumentException>(() => rule.IsRespected("abc"));
        }

    }
}
