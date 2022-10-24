using NUnit.Framework;
using PersonalNumberChecker.Validation.Rules;

namespace PersonalNumberChecker.Tests.Validation
{
    public class BirthDateRuleTests
    {
        private BirthDateRule rule;

        [SetUp]
        public void Init()
        {
            //Arrange
            this.rule = new BirthDateRule();
        }

        [Test]
        public void RuleIsNotRespectedWhenDayIsTooHigh()
        {
            //Act
            bool isRespected = this.rule.IsRespected("8507330000");

            //Assert
            Assert.False(isRespected);
        }


        [Test]
        public void RuleIsNotRespectedWhenDayIsZero()
        {
            //Act
            bool isRespected = this.rule.IsRespected("8507000000");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsNotRespectedWhenDayDoesNotExist()
        {
            //Act
            bool isRespected = this.rule.IsRespected("8506310000");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsNotRespectedWhenMonthIsTooHighBeforeTwoThousand()
        {
            //Act
            bool isRespected = this.rule.IsRespected("8513050000");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsNotRespectedWhenMonthIsTooHighAfterTwoThousand()
        {
            //Act
            bool isRespected = this.rule.IsRespected("0353050000");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsNotRespectedWhenMonthIsZeroBeforeTwoThousand()
        {
            //Act
            bool isRespected = this.rule.IsRespected("8500050000");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsNotRespectedWhenMonthIsZeroAfterTwoThousand()
        {
            //Act
            bool isRespected = this.rule.IsRespected("0300050000");

            //Assert
            Assert.False(isRespected);
        }

        [Test]
        public void RuleIsRespectedAfterTwoThousand()
        {
            //Act
            bool isRespected = this.rule.IsRespected("0352059192");

            //Assert
            Assert.True(isRespected);
        }

        [Test]
        public void RuleIsRespectedBeforeTwoThousand()
        {
            //Act
            bool isRespected = this.rule.IsRespected("8507230000");

            //Assert
            Assert.True(isRespected);
        }
    }
}
