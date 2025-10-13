using Anycraft.Features.Configs;
using Anycraft.Features.Validation;
using UnityEngine;

namespace Anycraft.Features.Inventory.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Inventory/Configs/" + nameof(InventorySlotConfig))]
    public sealed class InventorySlotConfig : BaseSerializedConfig
    {
        public override void Validate()
        {
            this.ValidateAndThrow(new Validator());
        }
    }
}