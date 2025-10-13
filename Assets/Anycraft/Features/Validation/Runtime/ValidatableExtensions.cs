using JetBrains.Annotations;

namespace Anycraft.Features.Validation
{
    [UsedImplicitly]
    public static class ValidatableExtensions
    {
        public static void ValidateAndThrow(this IValidatable validatable)
        {
            if (validatable == null)
            {
                throw new ValidatationException("Validatable is nul");
            }
            var errorMessage = "";

            if (!validatable.Validate(ref errorMessage))
            {
                throw new ValidatationException(errorMessage);
            }
        }
    }
}

