using FizzBuzzCodeKata.Core.Models;

namespace FizzBuzzCodeKata.Core.Rules;

public interface IFizzBuzzRule
{
    string Execute(FizzbuzzModel model);
    bool RuleShouldRun(int number);
}
