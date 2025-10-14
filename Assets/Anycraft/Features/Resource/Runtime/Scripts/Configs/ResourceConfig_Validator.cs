using Anycraft.Features.Configs;
using Anycraft.Features.Validation;
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
                var validator = ValidatorCache.Get<
                    BaseSerializedConfig.Validator, BaseSerializedConfig>();
                
                Include(validator);
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow<
                BaseSerializedConfig.Validator, BaseSerializedConfig>();
        }
    }
}