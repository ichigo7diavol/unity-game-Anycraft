using FluentValidation;

namespace Anycraft.Features.Validation
{
    public static class ValidatableExtensions
    {
        public static void ValidateAndThrow<TValidatable>(this TValidatable validatable)
            where TValidatable : IValidatable
        {
            ValidatorCache
                .Get<TValidatable>()
                .ValidateAndThrow(validatable);
        }
    }
}