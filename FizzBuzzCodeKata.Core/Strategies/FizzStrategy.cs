namespace FizzBuzzCodeKata.Core.Strategies;

/// <summary>
/// The Fizz strategy, which applies where a lone %3 divisor result is 0 for a given number
/// </summary>
public class FizzStrategy : IFizzBuzzStrategy
{
    public string Name { get; private set; }

    public FizzStrategy()
    {
        Name = nameof(FizzStrategy);
    }

    public string ApplyStrategy() => "Fizz";
}