using Anycraft.FluentValidationExtensions.Configs;
using Anycraft.FluentValidationExtensions.Configs.Table;
using Anycraft.FluentValidationExtensions.Validation;
using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Items.Configs
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

                RuleFor(c => c._tagEntries)
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

