using FluentValidation;

namespace Anycraft.Features.Validation
{
    public static class ValidatableExtensions
    {
        public static void ValidateAndThrow<TSource>(
            this TSource validatable, AbstractValidator<TSource> validator)
            where TSource : IValidatable
        {
            var result = validator.Validate(validatable);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}