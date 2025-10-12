using Anycraft.Frame.Configs.Table;
using UnityEngine;

namespace Anycraft.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemsTagsTableConfig))]
    public sealed class ItemsTagsTableConfig : BaseTableConfig<ItemTagConfig>
    {
    }  
}