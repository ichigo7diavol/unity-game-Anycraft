using Anycraft.Features.Configs.Table;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Items) + "/" + nameof(ItemsTableConfig))]
    public sealed partial class ItemsTableConfig
        : BaseTableConfig<ItemConfig>
    {
    }
}