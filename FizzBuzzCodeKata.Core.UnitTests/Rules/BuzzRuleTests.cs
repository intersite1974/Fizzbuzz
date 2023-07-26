using FizzBuzzCodeKata.Core.Models;
using FizzBuzzCodeKata.Core.Rules;
using FizzBuzzCodeKata.Core.Services;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzzCodeKata.Core.UnitTests.Rules;

public class BuzzRuleTests
{
    private const int MinimumRange = 1;
    private const int MaximumRange = 100;

    [Fact]
    public void GIVEN_BuzzRule_WHEN_Execute_AND_ValidationFails_THEN_ShouldReturnError()
    {
        // Arrange
        var expectedError = "Oh oh, an error!";

        var model = new FizzbuzzModel
        {
            InputNumber = 50
        };

        Mock<IValidationService> validationServiceMock = new();
        validationServiceMock
            .Setup(x => x.ValidateInputModel(model))
            .Returns(expectedError);

        var sut = new BuzzRule(validationServiceMock.Object);

        // Act
        var result = sut.Execute(model);

        // Assert
        result.Should().Be(expectedError);
        validationServiceMock.Verify(x => x.ValidateInputModel(model), Times.Once);
    }

    [Theory]
    [MemberData(nameof(GetApplicableModBasedNumbers))]
    public void GIVEN_BuzzRule_WHEN_Execute_AND_ApplicableMod5NumbersInRange_THEN_ExpectedResultReturned(int inputValue)
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = inputValue
        };

        Mock<IValidationService> validationServiceMock = new();
        validationServiceMock
            .Setup(x => x.ValidateInputModel(model))
            .Returns(string.Empty);

        var sut = new BuzzRule(validationServiceMock.Object);

        // Act
        var result = sut.Execute(model);

        // Assert
        result.Should().Be("Buzz");
        validationServiceMock.Verify(x => x.ValidateInputModel(model), Times.Once);
    }

    [Theory]
    [MemberData(nameof(GetNonApplicableModBasedNumbers))]
    public void GIVEN_BuzzRule_WHEN_Execute_AND_NonApplicableMod5NumbersInRange_THEN_ExpectedResultReturned(int inputValue)
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = inputValue
        };

        Mock<IValidationService> validationServiceMock = new();
        validationServiceMock
            .Setup(x => x.ValidateInputModel(model))
            .Returns(string.Empty);

        var sut = new BuzzRule(validationServiceMock.Object);

        // Act
        var result = sut.Execute(model);

        // Assert
        result.Should().Be(string.Empty);
        validationServiceMock.Verify(x => x.ValidateInputModel(model), Times.Once);
    }

    public static IEnumerable<object[]> GetApplicableModBasedNumbers()
    {
        var result = new List<object[]>();

        for (var x = MinimumRange; x <= MaximumRange; x++)
        {
            if (x % 5 == 0)
            {
                result.Add(new object[] { x });
            }
        }

        return result;
    }

    public static IEnumerable<object[]> GetNonApplicableModBasedNumbers()
    {
        var result = new List<object[]>();

        for (var x = MinimumRange; x <= MaximumRange; x++)
        {
            if (x % 5 != 0)
            {
                result.Add(new object[] { x });
            }
        }

        return result;
    }

    public static IEnumerable<object[]> GetNonApplicableMod3AndMod5BasedNumbers()
    {
        var result = new List<object[]>();

        for (var x = MinimumRange; x <= MaximumRange; x++)
        {
            if (!(x % 3 == 0 && x % 5 == 0))
            {
                result.Add(new object[] { x });
            }
        }

        return result;
    }

    public static IEnumerable<object[]> GetApplicableMod3AndMod5BasedNumbers()
    {
        var result = new List<object[]>();

        for (var x = MinimumRange; x <= MaximumRange; x++)
        {
            if ((x % 3 == 0 && x % 5 == 0))
            {
                result.Add(new object[] { x });
            }
        }

        return result;
    }
}
