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
        Console.WriteLine("[1] - Run Fizzbuzz (Rules Pattern) using Fully Valid Number Range of 1-100");
        Console.WriteLine();
        Console.WriteLine("[ESC] - Exit the application {0}", Environment.NewLine);
    }
}
