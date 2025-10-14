using Anycraft.Features.Configs.Table;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemsTagsTableConfig))]
    public sealed class ItemsTagsTableConfig
        : BaseTableConfig<ItemTagConfig>
    {
        public new sealed class Validator
            : AbstractValidator<ItemsTagsTableConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseTableConfig<ItemTagConfig>.Validator,
                    BaseTableConfig<ItemTagConfig>>());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow<Validator, ItemsTagsTableConfig>();
        }
    }
}