using FizzBuzzCodeKata.Core.Strategies;
using FluentAssertions;
using Xunit;

namespace FizzBuzzCodeKata.Core.UnitTests.Services;

public class FizzbuzzStrategyTests
{
    [Fact]
    public void GIVEN_FizzBuzzStrategy_WHEN_ApplyStrategy_THEN_Expected_Return_Value()
    {
        // Arrange
        var sut = new FizzbuzzStrategy();

        // Act
        var result = sut.ApplyStrategy();

        // Assert
        result.Should().Be("Fizzbuzz");
    }
}
