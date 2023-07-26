using FizzBuzzCodeKata.Core.Models;

namespace FizzBuzzCodeKata.Core.Services;

public interface IFizzBuzzRuleEngine
{
    string ExecuteRules(FizzbuzzModel model);
}
