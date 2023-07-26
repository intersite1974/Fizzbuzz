namespace FizzBuzzCodeKata.Core.Attributes;

public class RangeMaximumAttribute : Attribute
{
    public int MaximumValue { get; set; }

    public RangeMaximumAttribute(int maximumValue)
    {
        MaximumValue = maximumValue;
    }
}
