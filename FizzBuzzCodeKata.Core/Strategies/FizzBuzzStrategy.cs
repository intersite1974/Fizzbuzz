namespace FizzBuzzCodeKata.Core.Strategies;

/// <summary>
/// The Fizzbuzz strategy, which applies where %3 AND %5 divisor results are both 0 for a given number 
/// </summary>
public class FizzbuzzStrategy : IFizzBuzzStrategy
{
    public string Name { get; private set; }

    public FizzbuzzStrategy()
    {
        Name = nameof(FizzbuzzStrategy);
    }

    public string ApplyStrategy() => "Fizzbuzz";
}