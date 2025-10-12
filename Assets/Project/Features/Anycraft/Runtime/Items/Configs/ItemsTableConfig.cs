using Anycraft.Frame.Configs.Table;
using UnityEngine;

namespace Anycraft.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemsTableConfig))]
    public sealed class ItemsTableConfig : BaseTableConfig<ItemConfig>
    {
    }   
}