using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Configs
{
    public abstract partial class BaseSerializedConfig
    {
        public sealed class Validator
            : AbstractValidator<BaseSerializedConfig>
        {
            public Validator()
            {
                RuleFor(c => c._id)
                    .NotNull()
                    .NotEmpty();
            }
        }

        public abstract void Validate();
    }
}