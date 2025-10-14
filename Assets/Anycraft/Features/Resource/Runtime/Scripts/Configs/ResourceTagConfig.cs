using Anycraft.Features.Tags.Configs;
using Anycraft.Features.Validation;
using FluentValidation;
using JetBrains.Annotations;

namespace Anycraft.Resource.Configs
{
    [UsedImplicitly]
    public sealed class ResourceTagConfig
        : BaseTagConfig
    {
        public new sealed class Validator
            : AbstractValidator<ResourceTagConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseTagConfig>());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow();
        }
    }
}