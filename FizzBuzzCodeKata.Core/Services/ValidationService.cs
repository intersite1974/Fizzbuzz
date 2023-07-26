using FizzBuzzCodeKata.Core.Attributes;
using FizzBuzzCodeKata.Core.Models;
using System.Reflection;

namespace FizzBuzzCodeKata.Core.Services;

/// <summary>
/// The ValidationService uses Reflection as a means to validate the input model (number) being processed. 
/// If set, both the minimum and maximums are checked as per the minimum and maximum custom attributes that are set on FizzbuzzModel.
/// 
/// In reality, FluentValidation or an alternative would be used, here we demonstrate the use of Reflection as a poor mans approach to 
/// Data Annotations etc. as a means to validate inbound data.
/// 
/// SOLID Principle (S) - Single Responsibility - this service does one thing only (validates input), but GetCustomAttribute code would
/// be better separated out.
/// </summary>
public class ValidationService : IValidationService
{
    public string ValidateInputModel(FizzbuzzModel model)
    {
        int? minValueAttribute = null;
        int? maxValueAttribute = null;

        foreach (var property in typeof(FizzbuzzModel).GetProperties())
        {
            minValueAttribute = ((RangeMinimumAttribute)property.GetCustomAttribute(typeof(RangeMinimumAttribute)))?.MinimumValue;
            maxValueAttribute = ((RangeMaximumAttribute)property.GetCustomAttribute(typeof(RangeMaximumAttribute)))?.MaximumValue;
        }

        if (minValueAttribute != null && model.InputNumber < minValueAttribute)
        {
            return $"The number specified ({model.InputNumber}) does not meet the minimum value permitted ({minValueAttribute})";
        }

        if (maxValueAttribute != null && model.InputNumber > maxValueAttribute)
        {
            return $"The number specified ({model.InputNumber}) exceeds the maximum value permitted ({maxValueAttribute})";
        }

        return string.Empty;
    }
}
