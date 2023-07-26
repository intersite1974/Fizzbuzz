using Ardalis.GuardClauses;
using FizzBuzzCodeKata.Core.Rules;
using FizzBuzzCodeKata.Core.Services;
using Microsoft.Extensions.DependencyInjection;

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

ConsoleKeyInfo keyReader;

// Render Menu
menuService?.RenderMainMenu();

do
{
    keyReader = Console.ReadKey(true);

    switch (keyReader.KeyChar.ToString())
    {
        case "1":
            Console.WriteLine("TBC");
            break;
    }
}
while (keyReader.Key != ConsoleKey.Escape);
