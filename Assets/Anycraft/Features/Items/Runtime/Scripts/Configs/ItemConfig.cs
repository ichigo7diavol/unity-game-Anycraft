using Anycraft.Features.Configs;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Items) + "/" + nameof(Configs) + "/" + nameof(ItemConfig))]
    public sealed partial class ItemConfig
        : BaseSerializedConfig
    {
        [HideInInspector][SerializeField] private ItemTagTableEntries _tags;
    }
}

