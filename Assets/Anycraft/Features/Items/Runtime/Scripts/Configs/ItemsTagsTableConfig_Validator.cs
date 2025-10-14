using Anycraft.Features.Configs.Table;
using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Items.Configs
{
    public sealed partial class ItemsTagsTableConfig
        : BaseTableConfig<ItemTagConfig>
    {
        public new sealed class Validator
            : AbstractValidator<ItemsTagsTableConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                <
                    BaseTableConfig<ItemTagConfig>.Validator,
                    BaseTableConfig<ItemTagConfig>
                >());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                BaseTableConfig<ItemTagConfig>.Validator,
                BaseTableConfig<ItemTagConfig>
            >();
        }
    }
}