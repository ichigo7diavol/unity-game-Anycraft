using Anycraft.Features.Configs;
using UnityEngine;

namespace Anycraft.Features.Inventory.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Inventory) + "/" + nameof(Configs) + "/" + nameof(InventorySlotConfig))]
    public sealed partial class InventorySlotConfig
        : BaseSerializedConfig
    {
    }
}