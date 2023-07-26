namespace FizzBuzzCodeKata.Core.Services;

/// <summary>
/// (S)OLID : MenuService does one thing only, it renders a main menu
/// </summary>
public class MenuService : IMenuService
{
    public void RenderMainMenu()
    {
        Console.WriteLine("Choose an option from below..");
        Console.WriteLine();
        Console.WriteLine("[1] - Run Fizzbuzz Approach 1 (Rules Pattern) using Fully Valid Number Range of 1-100");
        Console.WriteLine();
        Console.WriteLine("[2] - Run Fizzbuzz Approach 2 (Strategy Pattern) using Fully Valid Number Range of 1-100");
        Console.WriteLine();
        Console.WriteLine("[3] - Run Fizzbuzz Approach 2 (Strategy Pattern) to test Reflection using invalid out of range number -1");
        Console.WriteLine();
        Console.WriteLine("[4] - Run Fizzbuzz Approach 2 (Strategy Pattern) to test Reflection using invalid out of range number 101");
        Console.WriteLine();
        Console.WriteLine("[ESC] - Exit the application {0}", Environment.NewLine);
    }
}