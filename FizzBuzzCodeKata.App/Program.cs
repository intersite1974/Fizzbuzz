using FizzBuzzCodeKata.Core.Rules;
using FizzBuzzCodeKata.Core.Services;
using Microsoft.Extensions.DependencyInjection;

// Register Services with Dependency Injection Container
var serviceProvider = new ServiceCollection()
    .AddTransient<IValidationService, ValidationService>()
    .AddTransient<IFizzBuzzRule, FizzRule>()
    .AddTransient<IFizzBuzzRule, BuzzRule>()
    .AddTransient<IFizzBuzzRule, FizzBuzzRule>()
    .BuildServiceProvider();

Console.WriteLine("Hello World");