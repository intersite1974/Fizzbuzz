using FizzBuzzCodeKata.Core.Strategies;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzzCodeKata.Core.UnitTests.Services;

public class FizzBuzzStrategyResolverTests
{
    private const int MinimumRange = 1;
    private const int MaximumRange = 100;

    [Fact]
    public void GIVEN_FizzBuzzStrategyResolver_WHEN_GetStrategy_StrategyNotFound_Throws()
    {
        // Arrange
        Mock<List<IFizzBuzzStrategy>> strategies = new();
        strategies.Object.Add(new BuzzStrategy());
        var sut = new FizzBuzzStrategyResolver(strategies.Object);

        // Act
        var action = () =>
        {
            _ = sut.GetStrategy("SomeUnknownStrategy");
        };

        // Assert
        _ = action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GIVEN_FizzBuzzStrategyResolver_WHEN_GetStrategy_StrategyFound_DoesNotThrow()
    {
        // Arrange
        Mock<List<IFizzBuzzStrategy>> strategies = new();
        strategies.Object.Add(new FizzStrategy());
        var sut = new FizzBuzzStrategyResolver(strategies.Object);

        // Act
        var action = () =>
        {
            _ = sut.GetStrategy(nameof(FizzStrategy));
        };

        // Assert
        _ = action.Should().NotThrow<ArgumentOutOfRangeException>();
    }

    [Theory]
    [MemberData(nameof(GetApplicableMod3BasedNumbers))]
    public void GIVEN_FizzBuzzStrategyResolver_WHEN_Resolve_AND_NumberIs_Purely_FizzMod3_THEN_FizzStrategy_Returned(int inputNumber)
    {
        // Arrange
        var strategies = GetStrategies();

        var sut = new FizzBuzzStrategyResolver(strategies);

        // Act
        var result = sut.Resolve(inputNumber);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(strategies.Find(x => x.GetType() == typeof(FizzStrategy)));
    }

    [Theory]
    [MemberData(nameof(GetApplicableMod5BasedNumbers))]
    public void GIVEN_FizzBuzzStrategyResolver_WHEN_Resolve_AND_NumberIs_Purely_BuzzMod5_THEN_BuzzStrategy_Returned(int inputNumber)
    {
        // Arrange
        var strategies = GetStrategies();

        var sut = new FizzBuzzStrategyResolver(strategies);

        // Act
        var result = sut.Resolve(inputNumber);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(strategies.Find(x => x.GetType() == typeof(BuzzStrategy)));
    }

    [Theory]
    [MemberData(nameof(GetApplicableMod3AndMod5BasedNumbers))]
    public void GIVEN_FizzBuzzStrategyResolver_WHEN_Resolve_AND_NumberIs_FizzMod3_AND_BuzzMod5_THEN_FizzBuzzStrategy_Returned(int inputNumber)
    {
        // Arrange
        var strategies = GetStrategies();

        var sut = new FizzBuzzStrategyResolver(strategies);

        // Act
        var result = sut.Resolve(inputNumber);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(strategies.Find(x => x.GetType() == typeof(FizzbuzzStrategy)));
    }

    private static List<IFizzBuzzStrategy> GetStrategies()
    {
        var strategies = new Mock<List<IFizzBuzzStrategy>>();
        strategies.Object.Add(new FizzStrategy());
        strategies.Object.Add(new BuzzStrategy());
        strategies.Object.Add(new FizzbuzzStrategy());
        return strategies.Object;
    }

    public static IEnumerable<object[]> GetApplicableMod3BasedNumbers()
    {
        var result = new List<object[]>();

        for (var x = MinimumRange; x <= MaximumRange; x++)
        {
            if (x % 3 == 0 && x % 5 != 0)
            {
                result.Add(new object[] { x });
            }
        }

        return result;
    }

    public static IEnumerable<object[]> GetApplicableMod5BasedNumbers()
    {
        var result = new List<object[]>();

        for (var x = MinimumRange; x <= MaximumRange; x++)
        {
            if (x % 5 == 0 && x % 3 != 0)
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
            if (x % 3 == 0 && x % 5 == 0)
            {
                result.Add(new object[] { x });
            }
        }

        return result;
    }
}
