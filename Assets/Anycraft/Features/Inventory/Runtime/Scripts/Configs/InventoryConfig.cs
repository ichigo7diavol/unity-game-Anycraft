using Anycraft.Features.Configs;
using UnityEngine;

namespace Anycraft.Features.Inventory.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Inventory) + "/" + nameof(Configs) + "/" + nameof(InventoryConfig))]
    public sealed partial class InventoryConfig
        : BaseSerializedConfig
    {
    }
}