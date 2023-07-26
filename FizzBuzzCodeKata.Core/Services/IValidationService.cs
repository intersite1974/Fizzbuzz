using FizzBuzzCodeKata.Core.Models;

namespace FizzBuzzCodeKata.Core.Services;

public interface IValidationService
{
    string ValidateInputModel(FizzbuzzModel model);
}
