using NUnit.Framework;
using PersonalNumberChecker.Validation.Rules;

namespace PersonalNumberChecker.Tests.Validation
{
    public class LengthRuleTests
    {
        private LengthRule rule;

        [SetUp]
        public void Init()
        {
            //Arrange
            this.rule= new LengthRule(); ;
        }

        [Test]
        public void RuleIsNotRespectedWhenLengthGreaterThanTen()
        {
            //Act
            bool isRespected = this.rule.IsRespected("12345678901");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsNotRespectedWhenLengthSmallerThanTen()
        {
            //Act
            bool isRespected = this.rule.IsRespected("12345");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsRespectedWhenLengthExactlyTen()
        {
            //Act
            bool isRespected = rule.IsRespected("1234567890");

            //Assert
            Assert.True(isRespected);
        }
    }
}
