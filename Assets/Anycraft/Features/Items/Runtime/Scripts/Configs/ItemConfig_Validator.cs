using Anycraft.Features.Configs;
using Anycraft.Features.Configs.Table;
using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Items.Configs
{
    public sealed partial class ItemConfig
    {
        public new sealed class Validator
            : AbstractValidator<ItemConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<
                    BaseSerializedConfig.Validator, BaseSerializedConfig>());

                RuleFor(c => c._tags)
                    .NotNull()
                    .SetValidator(ValidatorCache.Get
                    <
                        BaseTableEntries<ItemsTagsTableConfig, ItemTagConfig>.Validator,
                        BaseTableEntries<ItemsTagsTableConfig, ItemTagConfig>
                    >());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                Validator,
                ItemConfig
            >();
        }
    }
}

