using Anycraft.FluentValidationExtensions.Configs;
using Anycraft.FluentValidationExtensions.Validation;
using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Resource.Configs
{
    public sealed partial class ResourceConfig
    {
        public new sealed class Validator
            : AbstractValidator<ResourceConfig>
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
                ResourceConfig
            >();
        }
    }
}