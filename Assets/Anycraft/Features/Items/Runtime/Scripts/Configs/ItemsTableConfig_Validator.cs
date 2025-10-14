using Anycraft.Features.Configs.Table;
using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Items.Configs
{
    public sealed partial class ItemsTableConfig
    {
        public new sealed class Validator
            : AbstractValidator<ItemsTableConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                <
                    BaseTableConfig<ItemConfig>.Validator,
                    BaseTableConfig<ItemConfig>
                >());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                BaseTableConfig<ItemConfig>.Validator,
                BaseTableConfig<ItemConfig>
            >();
        }
    }
}