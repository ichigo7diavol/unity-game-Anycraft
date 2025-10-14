using Anycraft.Features.Configs.Table;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Items) + "/" + nameof(Configs) + "/" + nameof(ItemsTagsTableConfig))]
    public sealed partial class ItemsTagsTableConfig
        : BaseTableConfig<ItemTagConfig>
    {
    }
}