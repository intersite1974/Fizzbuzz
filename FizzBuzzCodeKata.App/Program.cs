using Ardalis.GuardClauses;
using FizzBuzzCodeKata.Core.Models;
using FizzBuzzCodeKata.Core.Rules;
using FizzBuzzCodeKata.Core.Services;
using FizzBuzzCodeKata.Core.Strategies;
using Microsoft.Extensions.DependencyInjection;

// Range values as mandated by the requirements brief
const int NumberRangeMin = 1;
const int NumberRangeMax = 100;

// Register Services with Dependency Injection Container
var serviceProvider = new ServiceCollection()
    .AddTransient<IMenuService, MenuService>()
    .AddTransient<IValidationService, ValidationService>()
    .AddTransient<IFizzBuzzRuleEngine, FizzBuzzRuleEngine>()
    .AddTransient<IFizzBuzzRule, FizzRule>()
    .AddTransient<IFizzBuzzRule, BuzzRule>()
    .AddTransient<IFizzBuzzRule, FizzBuzzRule>()
    .AddTransient<IFizzBuzzStrategyResolver, FizzBuzzStrategyResolver>()
    .AddTransient<IFizzBuzzStrategy, FizzbuzzStrategy>()
    .AddTransient<IFizzBuzzStrategy, FizzStrategy>()
    .AddTransient<IFizzBuzzStrategy, BuzzStrategy>()
    .BuildServiceProvider();

var menuService = Guard.Against.Null(serviceProvider.GetService<IMenuService>());
var numberValidationService = Guard.Against.Null(serviceProvider.GetService<IValidationService>());
var fizzBuzzStrategyResolver = Guard.Against.Null(serviceProvider.GetService<IFizzBuzzStrategyResolver>());
var fizzBuzzRuleEngine = Guard.Against.Null(serviceProvider.GetService<IFizzBuzzRuleEngine>());

ConsoleKeyInfo keyReader;

// Render Menu
menuService?.RenderMainMenu();

do
{
    keyReader = Console.ReadKey(true);

    switch (keyReader.KeyChar.ToString())
    {
        // Approach 1 - Rules Pattern
        case "1":
            ProcessFullRangeOfValidNumbersApproach1();
            break;

        // Approach 2 - Strategy Pattern
        case "2":
            ProcessFullRangeOfValidNumbersApproach2();
            break;

        // Approach 2 - Strategy Pattern
        case "3":
            ProcessInvalidNumberApproach2(-1);
            break;

        // Aproach 2 - Strategy Pattern
        case "4":
            ProcessInvalidNumberApproach2(101);
            break;
    }
}
while (keyReader.Key != ConsoleKey.Escape);

void ProcessFullRangeOfValidNumbersApproach1()
{
    Console.WriteLine("Approach 1 (Rules Pattern)");

    var model = new FizzbuzzModel();

    for (var number = NumberRangeMin; number <= NumberRangeMax; number++)
    {
        model.InputNumber = number;
        Console.WriteLine(fizzBuzzRuleEngine?.ExecuteRules(model));
    }
}

void ProcessFullRangeOfValidNumbersApproach2()
{
    Console.WriteLine("Approach 2 (Strategy Pattern)");

    var model = new FizzbuzzModel();

    for (var number = NumberRangeMin; number <= NumberRangeMax; number++)
    {
        model.InputNumber = number;

        var validationResult = numberValidationService?.ValidateInputModel(model);

        if (!string.IsNullOrEmpty(validationResult))
        {
            Console.WriteLine(validationResult);
            continue;
        }

        var resolvedStrategy = fizzBuzzStrategyResolver?.Resolve(number);

        if (resolvedStrategy == null)
        {
            Console.WriteLine(number);
        }
        else
        {
            Console.WriteLine(resolvedStrategy.ApplyStrategy());
        }
    }
}

void ProcessInvalidNumberApproach2(int number)
{
    var invalidModelMin = new FizzbuzzModel
    {
        InputNumber = number
    };

    var invalidMinValidationResult = numberValidationService?.ValidateInputModel(invalidModelMin);

    if (!string.IsNullOrEmpty(invalidMinValidationResult))
    {
        Console.WriteLine(invalidMinValidationResult);
    }
    else
    {
        // We wont reach here!
        var resolvedStrategy = fizzBuzzStrategyResolver?.Resolve(number);

        if (resolvedStrategy == null)
        {
            Console.WriteLine(number);
        }
        else
        {
            Console.WriteLine(resolvedStrategy.ApplyStrategy());
        }
    }
}
