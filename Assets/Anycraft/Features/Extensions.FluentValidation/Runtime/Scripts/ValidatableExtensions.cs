using FluentValidation;

namespace Anycraft.Features.Extensions.FluentValidation
{
    public static class ValidatableExtensions
    {
        public static void ValidateAndThrow<TValidator, TValidatable>(this TValidatable validatable)
            where TValidator : IValidator<TValidatable>, new()
        {
            ValidatorCache
                .Get<TValidator, TValidatable>()
                .ValidateAndThrow(validatable);
        }
    }
}