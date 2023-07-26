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

    [Fact]
    public void GIVEN_FizzBuzzRuleEngine_WHEN_ExecuteRules_THEN_Expected_Calls_To_Rules_Made()
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = 50
        };

        Mock<IValidationService> validationServiceMock = new();
        validationServiceMock
            .Setup(x => x.ValidateInputModel(model))
            .Returns(string.Empty);

        Mock<IFizzBuzzRule> ruleMock1 = new();
        ruleMock1
            .Setup(x => x.RuleShouldRun(model.InputNumber))
            .Returns(false);

        Mock<IFizzBuzzRule> ruleMock2 = new();
        ruleMock2
            .Setup(x => x.RuleShouldRun(model.InputNumber))
            .Returns(true);

        ruleMock2
            .Setup(x => x.Execute(model))
            .Returns(string.Empty);

        Mock<IFizzBuzzRule> ruleMock3 = new();
        ruleMock3
            .Setup(x => x.RuleShouldRun(model.InputNumber))
            .Returns(true);

        ruleMock3
            .Setup(x => x.Execute(model))
            .Returns("Buzz");

        var rules = new Mock<List<IFizzBuzzRule>>();

        rules.Object.Add(ruleMock1.Object);
        rules.Object.Add(ruleMock2.Object);
        rules.Object.Add(ruleMock3.Object);

        var sut = new FizzBuzzRuleEngine(rules.Object);

        // Act
        var result = sut.ExecuteRules(model);

        // Assert
        ruleMock1.Verify(x => x.RuleShouldRun(model.InputNumber), Times.Once);
        ruleMock2.Verify(x => x.RuleShouldRun(model.InputNumber), Times.Once);
        ruleMock3.Verify(x => x.RuleShouldRun(model.InputNumber), Times.Once);

        ruleMock1.Verify(x => x.Execute(model), Times.Never);
        ruleMock2.Verify(x => x.Execute(model), Times.Once);
        ruleMock3.Verify(x => x.Execute(model), Times.Once);
    }

    [Fact]
    public void GIVEN_FizzBuzzRuleEngine_WHEN_ExecuteRules_AND_Rule_Returns_Non_Empty_Result_THEN_Expected_Result_Returned()
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = 50
        };

        Mock<IValidationService> validationServiceMock = new();
        validationServiceMock
            .Setup(x => x.ValidateInputModel(model))
            .Returns(string.Empty);

        Mock<IFizzBuzzRule> ruleMock1 = new();
        ruleMock1
            .Setup(x => x.RuleShouldRun(model.InputNumber))
            .Returns(true);

        ruleMock1
            .Setup(x => x.Execute(model))
            .Returns("Buzz");

        var rules = new Mock<List<IFizzBuzzRule>>();

        rules.Object.Add(ruleMock1.Object);

        var sut = new FizzBuzzRuleEngine(rules.Object);

        // Act
        var result = sut.ExecuteRules(model);

        // Assert
        result.Should().Be("Buzz");
        ruleMock1.Verify(x => x.RuleShouldRun(model.InputNumber), Times.Once);
        ruleMock1.Verify(x => x.Execute(model), Times.Once);
    }

    [Fact]
    public void GIVEN_FizzBuzzRuleEngine_WHEN_ExecuteRules_AND_Rule_Returns_Empty_Result_THEN_Expected_InputNumber_Returned()
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = 50
        };

        Mock<IValidationService> validationServiceMock = new();
        validationServiceMock
            .Setup(x => x.ValidateInputModel(model))
            .Returns(string.Empty);

        Mock<IFizzBuzzRule> ruleMock1 = new();
        ruleMock1
            .Setup(x => x.RuleShouldRun(model.InputNumber))
            .Returns(true);

        ruleMock1
            .Setup(x => x.Execute(model))
            .Returns(string.Empty);

        var rules = new Mock<List<IFizzBuzzRule>>();

        rules.Object.Add(ruleMock1.Object);

        var sut = new FizzBuzzRuleEngine(rules.Object);

        // Act
        var result = sut.ExecuteRules(model);

        // Assert
        result.Should().Be(model.InputNumber.ToString());
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
