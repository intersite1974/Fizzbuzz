namespace FizzBuzzCodeKata.Core.Strategies;

public interface IFizzBuzzStrategyResolver
{
    IFizzBuzzStrategy? Resolve(int number);
}
