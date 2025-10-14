using Anycraft.FluentValidationExtensions.Configs;
using Anycraft.FluentValidationExtensions.Validation;
using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Tags.Configs
{
    public abstract partial class BaseTagConfig
    {
        public new sealed class Validator
            : AbstractValidator<BaseTagConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                <
                    BaseSerializedConfig.Validator,
                    BaseSerializedConfig
                >());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                Validator,
                BaseTagConfig
            >();
        }
    }
}

