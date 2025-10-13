using Anycraft.Features.Configs.Table;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemsTableConfig))]
    public sealed class ItemsTableConfig : BaseTableConfig<ItemConfig>
    {
    }   
}