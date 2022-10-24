using Moq;
using NUnit.Framework;
using PersonalNumberChecker.Interfaces.Presentation;
using PersonalNumberChecker.Interfaces.Validation;
using PersonalNumberChecker.Parsing;
using System;
using System.Linq;

namespace PersonalNumberChecker.Tests.Parsing
{
    public class PersonalNumberParserTests
    {
        private PersonalNumberParser parser;

        [SetUp]
        public void Init()
        {
            //Arrange
            Mock<IPersonalNumberValidator> validator = new Mock<IPersonalNumberValidator>();
            validator.Setup(v => v.Validate(It.IsAny<string>())).Returns(Enumerable.Empty<ValidationError>());
            this.parser = new PersonalNumberParser(validator.Object);
        }

        [Test]
        public void GenderMaleIsParsedCorrectly()
        {
            //Act
            var result = parser.ParsePersonalNumber("8507230040");

            //Assert
            Assert.AreEqual(Gender.Male, result.Gender);
        }

        [Test]
        public void GenderFemaleIsParsedCorrectly()
        {
            //Act
            var result = parser.ParsePersonalNumber("8507230030");

            //Assert
            Assert.AreEqual(Gender.Female, result.Gender);
        }

        [Test]
        public void BirthDateBeforeTwoThousandIsParsedCorrectly()
        {
            //Act
            var result = parser.ParsePersonalNumber("8507230030");

            //Assert
            var expectedDate = new DateTime(1985, 7, 23);
            Assert.AreEqual(expectedDate, result.BirthDate);
        }

        [Test]
        public void BirthDateAfterTwoThousandIsParsedCorrectly()
        {
            //Act
            var result = parser.ParsePersonalNumber("0350059192");

            //Assert
            var expectedDate = new DateTime(2003, 10, 5);
            Assert.AreEqual(expectedDate, result.BirthDate);
        }
    }
}
