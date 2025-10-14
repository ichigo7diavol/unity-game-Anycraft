using Anycraft.Features.Configs.Table;
using Anycraft.Features.Validation;
using FluentValidation;
using JetBrains.Annotations;

namespace Anycraft.Resource.Configs
{
    [UsedImplicitly]
    public sealed class ResourceTagsTableConfig
        : BaseTableConfig<ResourceTagConfig>
    {
        public new sealed class Validator
            : AbstractValidator<ResourceTagsTableConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseTableConfig<ResourceTagConfig>>());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow();
        }
    }
}