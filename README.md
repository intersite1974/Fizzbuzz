## FizzBuzz Code Kata

Repository for a sample FizzBuzz code kata.

Constructed using:

- Microsoft Visual Studio 2022
- [Microsoft .Net 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [XUnit](https://xunit.github.io/)
- [Moq](https://github.com/moq/moq/)
- [Fluent Assertions](http://www.fluentassertions.com/)

2 approaches are offered in the solution, one using a Rules Pattern based approach, the other using a Strategy Pattern approach.

I personally prefer the Rules Pattern based approach - although FizzBuzz is based on a small set of logic / rules, in the real world, a Rules
based implementation would be more extensible against future business rule / logic changes and seeks to keep the level of impact lower, as you
add rules as you need.

I also prefer the Rule pattern approach over the Strategy pattern approach becuase I think the Rules are more cleanly unit testable.

Also attempts to demonstrate various SOLID principles as well as the design patterns.

PLEASE NOTE - Reflection:

I implemented Reflection using CustomAttributes as you will see in the code.

I considered using Reflection via a "AppDomain.CurrentDomain.GetAssemblies" approach to populating the list of Rules (IFizzBuzzRule interface based) with GetTypes etc. but
I opted to use DI to do this instead as I think this is much cleaner and also made for easier unit testing.

