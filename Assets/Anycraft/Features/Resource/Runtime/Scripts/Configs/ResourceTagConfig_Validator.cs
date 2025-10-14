using Anycraft.Features.Tags.Configs;
using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Resource.Configs
{
    public sealed partial class ResourceTagConfig
    {
        public new sealed class Validator
            : AbstractValidator<ResourceTagConfig>
        {
            public Validator()
            {
                var validator = ValidatorCache.Get<
                    BaseTagConfig.Validator, BaseTagConfig>();

                Include(validator);
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow<
                BaseTagConfig.Validator, BaseTagConfig>();
        }
    }
}