using Ardalis.GuardClauses;
using FizzBuzzCodeKata.Core.Models;
using FizzBuzzCodeKata.Core.Rules;
using FizzBuzzCodeKata.Core.Services;
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
    .BuildServiceProvider();

var menuService = Guard.Against.Null(serviceProvider.GetService<IMenuService>());
var fizzBuzzRuleEngine = Guard.Against.Null(serviceProvider.GetService<IFizzBuzzRuleEngine>());


ConsoleKeyInfo keyReader;

// Render Menu
menuService?.RenderMainMenu();

do
{
    keyReader = Console.ReadKey(true);

    switch (keyReader.KeyChar.ToString())
    {
        case "1":
            ProcessFullRangeOfValidNumbersApproach1();
            break;
    }
}
while (keyReader.Key != ConsoleKey.Escape);

void ProcessFullRangeOfValidNumbersApproach1()
{
    Console.WriteLine("Rules Pattern");

    var model = new FizzbuzzModel();

    for (var number = NumberRangeMin; number <= NumberRangeMax; number++)
    {
        model.InputNumber = number;
        Console.WriteLine(fizzBuzzRuleEngine?.ExecuteRules(model));
    }
}
