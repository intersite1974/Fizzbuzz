using FizzBuzzCodeKata.Core.Strategies;
using FluentAssertions;
using Xunit;

namespace FizzBuzzCodeKata.Core.UnitTests.Services;

public class BuzzStrategyTests
{
    [Fact]
    public void GIVEN_BuzzStrategy_WHEN_ApplyStrategy_THEN_Expected_Return_Value()
    {
        // Arrange
        var sut = new BuzzStrategy();

        // Act
        var result = sut.ApplyStrategy();

        // Assert
        result.Should().Be("Buzz");
    }
}
