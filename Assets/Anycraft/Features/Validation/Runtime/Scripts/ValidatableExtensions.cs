using FluentValidation;

namespace Anycraft.Features.Validation
{
    public static class ValidatableExtensions
    {
        public static void ValidateAndThrow<TValidator, TValidatable>(this TValidatable validatable)
            where TValidator : IValidator<TValidatable>, new()
            where TValidatable : IValidatable
        {
            ValidatorCache
                .Get<TValidator, TValidatable>()
                .ValidateAndThrow(validatable);
        }
    }
}