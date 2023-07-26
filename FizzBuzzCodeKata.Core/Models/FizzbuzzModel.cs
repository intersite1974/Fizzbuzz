using FizzBuzzCodeKata.Core.Attributes;

namespace FizzBuzzCodeKata.Core.Models;

/// <summary>
/// Model that holds the input number to be processed.
/// 
/// Note use of 2 custom attributes.
/// 
/// The use of this model is a bit sledge hammery for this code kata, but it allows us to demonstrate some poor man's validation using Reflection.
/// </summary>
public class FizzbuzzModel
{
    [RangeMinimum(1)]
    [RangeMaximum(100)]
    public int InputNumber { get; set; }
}
