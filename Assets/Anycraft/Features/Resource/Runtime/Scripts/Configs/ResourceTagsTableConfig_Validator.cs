using Anycraft.Features.Configs.Table;
using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Resource.Configs
{
    public sealed partial class ResourceTagsTableConfig
    {
        public new sealed class Validator
            : AbstractValidator<ResourceTagsTableConfig>
        {
            public Validator()
            {
                var validator = ValidatorCache.Get<
                    BaseTableConfig<ResourceTagConfig>.Validator, BaseTableConfig<ResourceTagConfig>>();
                
                Include(validator);
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow<BaseTableConfig<
                ResourceTagConfig>.Validator, BaseTableConfig<ResourceTagConfig>>();
        }
    }
}