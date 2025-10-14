using Anycraft.Features.Configs;
using Anycraft.Features.FluentValidationExtensions;
using FluentValidation;

namespace Anycraft.Features.Resource.Configs
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