namespace FizzBuzzCodeKata.Core.Strategies;

/// <summary>
/// The Buzz strategy, which applies where a lone %5 divisor result is 0 for a given number
/// </summary>
public class BuzzStrategy : IFizzBuzzStrategy
{
    public string Name { get; private set; }

    public BuzzStrategy()
    {
        Name = nameof(BuzzStrategy);
    }

    public string ApplyStrategy() => "Buzz";
}