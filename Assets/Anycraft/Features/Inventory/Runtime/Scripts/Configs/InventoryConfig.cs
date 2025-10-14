using Anycraft.FluentValidationExtensions.Configs;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Inventory.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Inventory) + "/" + nameof(Configs) + "/" + nameof(InventoryConfig))]
    public sealed partial class InventoryConfig
        : BaseSerializedConfig
    {
    }
}