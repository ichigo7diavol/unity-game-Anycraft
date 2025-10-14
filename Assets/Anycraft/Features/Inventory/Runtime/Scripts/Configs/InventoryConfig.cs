using Anycraft.Features.Configs;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Inventory.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Inventory/Configs/" + nameof(InventoryConfig))]
    public sealed class InventoryConfig
        : BaseSerializedConfig
    {
        public new sealed class Validator
            : AbstractValidator<InventoryConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseSerializedConfig.Validator,
                    BaseSerializedConfig>());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow<Validator, InventoryConfig>();
        }
    }
}