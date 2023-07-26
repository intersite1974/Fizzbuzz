using Ardalis.GuardClauses;
using FizzBuzzCodeKata.Core.Models;
using FizzBuzzCodeKata.Core.Rules;
using System.Text;

namespace FizzBuzzCodeKata.Core.Services;

/// <summary>
/// Rules (Engine) pattern approach - allows for future extension as more logic/rules may surface without the need to amend large areas of code
/// as rules are added when necessary and will be executed as they are in the collection of FizzBuzz rules.
/// 
/// Individual Rules themselves can be finely tuned by way of logic to achieve the result needed.
/// 
/// </summary>
public class FizzBuzzRuleEngine : IFizzBuzzRuleEngine
{
    private readonly IEnumerable<IFizzBuzzRule> _fizzBuzzRules;

    public FizzBuzzRuleEngine(IEnumerable<IFizzBuzzRule> fizzBuzzRules)
    {
        _fizzBuzzRules = Guard.Against.NullOrEmpty(fizzBuzzRules);
    }

    public string ExecuteRules(FizzbuzzModel model)
    {
        Guard.Against.Null(model);

        var ruleResult = new StringBuilder();

        foreach (var rule in _fizzBuzzRules)
        {
            if (rule.RuleShouldRun(model.InputNumber))
            {
                ruleResult.Append(rule.Execute(model));
            }
        }

        return string.IsNullOrEmpty(ruleResult.ToString())
            ? model.InputNumber.ToString()
            : ruleResult.ToString();
    }
}
