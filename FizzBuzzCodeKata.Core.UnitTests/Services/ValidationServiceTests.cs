using FizzBuzzCodeKata.Core.Models;
using FizzBuzzCodeKata.Core.Services;
using FluentAssertions;
using Xunit;

namespace FizzBuzzCodeKata.Core.UnitTests.Services;

public class ValidationServiceTests
{
    private readonly ValidationService _sut;

    public ValidationServiceTests()
    {
        _sut = new ValidationService();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(-100)]
    [InlineData(-1000)]
    [InlineData(-10000)]
    public void GIVEN_ValidationService_WHEN_ValidateInputModel_AND_MinimumRangeNotMet_THEN_ShouldReturnError(int number)
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = number
        };

        // Act
        var result = _sut.ValidateInputModel(model);

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Be($"The number specified ({model.InputNumber}) does not meet the minimum value permitted (1)");
    }

    [Theory]
    [InlineData(101)]
    [InlineData(1001)]
    [InlineData(10001)]
    [InlineData(100001)]
    [InlineData(1000001)]
    public void GIVEN_ValidationService_WHEN_ValidateInputModel_AND_MaximumRangeExceeded_THEN_ShouldReturnError(int number)
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = number
        };

        // Act
        var result = _sut.ValidateInputModel(model);

        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeNullOrEmpty();
        result.Should().Be($"The number specified ({model.InputNumber}) exceeds the maximum value permitted (100)");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(24)]
    [InlineData(44)]
    [InlineData(65)]
    [InlineData(99)]
    [InlineData(100)]
    public void GIVEN_ValidationService_WHEN_ValidateInputModel_AND_ValidRangeValue_THEN_ShouldNotReturnError(int number)
    {
        // Arrange
        var model = new FizzbuzzModel
        {
            InputNumber = number
        };

        // Act
        var result = _sut.ValidateInputModel(model);

        // Assert
        result.Should().BeEmpty();
    }
}
