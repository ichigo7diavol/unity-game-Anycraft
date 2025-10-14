using Anycraft.FluentValidationExtensions.Configs;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Items.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Items) + "/" + nameof(Configs) + "/" + nameof(ItemConfig))]
    public sealed partial class ItemConfig
        : BaseSerializedConfig
    {
        [HideInInspector] [SerializeField] private ItemTagTableEntries _tagEntries;
    }
}

