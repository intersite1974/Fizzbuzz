using Ardalis.GuardClauses;

namespace FizzBuzzCodeKata.Core.Strategies;

/// <summary>
/// The FizzBuzzStrategyResolver is the logic handling work horse that determines / resolves the correct strategy to apply based on the outcome /
/// divisor checks.
/// 
/// We also use some type safety by way of safe lookups of the strategy name that applies from the collection of Fizz Buzz Strategies in order
/// to return it for subsequent use.
/// 
/// SOLID Principle (S) - resolves the correct strategy to use.
/// SOLID Principle (D) - dependency injection of the various IFizzBuzzStrategy based strategies.
/// </summary>
public class FizzBuzzStrategyResolver : IFizzBuzzStrategyResolver
{
    private readonly IEnumerable<IFizzBuzzStrategy> _fizzBuzzStrategies;

    public FizzBuzzStrategyResolver(IEnumerable<IFizzBuzzStrategy> fizzBuzzStrategies)
    {
        Guard.Against.NullOrEmpty(fizzBuzzStrategies);
        _fizzBuzzStrategies = fizzBuzzStrategies;
    }

    public IFizzBuzzStrategy? Resolve(int number)
    {
        var fizz = number % 3 == 0;
        var buzz = number % 5 == 0;

        if (fizz && buzz)
        {
            return GetStrategy(nameof(FizzbuzzStrategy));
        }

        if (fizz)
        {
            return GetStrategy(nameof(FizzStrategy));
        }

        if (buzz)
        {
            return GetStrategy(nameof(BuzzStrategy));
        }

        return null;
    }

    public IFizzBuzzStrategy GetStrategy(string name)
    {
        Guard.Against.NullOrEmpty(name);

        var theStrategy = _fizzBuzzStrategies.FirstOrDefault(x => x.Name == name);

        if (theStrategy == null)
        {
            throw new ArgumentOutOfRangeException(name, $"{nameof(GetStrategy)} - strategy not found!");
        }

        return theStrategy;
    }
}
