using Anycraft.Features.Configs;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(ItemConfig))]
    public sealed partial class ItemConfig
        : BaseIdentifiableConfig
    {
        [HideInInspector] 
        [SerializeField] private ItemTagTableEntries _tagEntries;
    }
}

