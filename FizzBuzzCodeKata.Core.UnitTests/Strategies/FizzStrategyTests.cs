using FizzBuzzCodeKata.Core.Strategies;
using FluentAssertions;
using Xunit;

namespace FizzBuzzCodeKata.Core.UnitTests.Services;

public class FizzStrategyTests
{
    [Fact]
    public void GIVEN_FizzStrategy_WHEN_ApplyStrategy_THEN_Expected_Return_Value()
    {
        // Arrange
        var sut = new FizzStrategy();

        // Act
        var result = sut.ApplyStrategy();

        // Assert
        result.Should().Be("Fizz");
    }
}
