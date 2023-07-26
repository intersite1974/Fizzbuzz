using FizzBuzzCodeKata.Core.Models;
using FizzBuzzCodeKata.Core.Rules;
using FizzBuzzCodeKata.Core.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzzCodeKata.Core.UnitTests.Services;

public class FizzBuzzRuleEngineTests
{
    [Fact]
    public void GIVEN_FizzBuzzRuleEngine_WHEN_ExecuteRules_AND_InputModel_Null_THEN_ShouldThrow()
    {
        // Arrange
        var rules = GetRules();
        var sut = new FizzBuzzRuleEngine(rules);

        // Act
        var action = () =>
        {
            _ = sut.ExecuteRules(null);
        };

        // Assert
        _ = action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GIVEN_FizzBuzzRuleEngine_WHEN_ExecuteRules_AND_InputModel_NotNull_THEN_ShouldNotThrow()
    {
        // Arrange
        var rules = GetRules();
        var sut = new FizzBuzzRuleEngine(rules);
        var model = new FizzbuzzModel
        {
            InputNumber = 50
        };

        // Act
        var action = () =>
        {
            _ = sut.ExecuteRules(model);
        };

        // Assert
        _ = action.Should().NotThrow<ArgumentNullException>();
    }

    private static List<IFizzBuzzRule> GetRules()
    {
        var rules = new Mock<List<IFizzBuzzRule>>();
        Mock<IValidationService> validationServiceMock = new();
        rules.Object.Add(new FizzRule(validationServiceMock.Object));
        rules.Object.Add(new BuzzRule(validationServiceMock.Object));
        rules.Object.Add(new FizzBuzzRule(validationServiceMock.Object));
        return rules.Object;
    }
}
