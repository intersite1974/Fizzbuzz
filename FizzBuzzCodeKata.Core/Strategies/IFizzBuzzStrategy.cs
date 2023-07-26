using FizzBuzzCodeKata.Core.Services;

namespace FizzBuzzCodeKata.Core.Strategies;

public interface IFizzBuzzStrategy
{
    string Name { get; }
    string ApplyStrategy();
}
