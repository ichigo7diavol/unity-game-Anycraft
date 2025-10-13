using Anycraft.Features.Configs.Table;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemsTableConfig))]
    public sealed class ItemsTableConfig : BaseTableConfig<ItemConfig>
    {
        public new sealed class Validator
            : AbstractValidator<ItemsTableConfig>
        {
            public Validator()
            {
                
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow(new Validator());
        }
    }
}