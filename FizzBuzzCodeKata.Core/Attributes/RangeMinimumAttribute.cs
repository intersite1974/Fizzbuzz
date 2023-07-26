namespace FizzBuzzCodeKata.Core.Attributes;

public class RangeMinimumAttribute : Attribute
{
    public int MinimumValue { get; set; }

    public RangeMinimumAttribute(int minimumValue)
    {
        MinimumValue = minimumValue;
    }
}
