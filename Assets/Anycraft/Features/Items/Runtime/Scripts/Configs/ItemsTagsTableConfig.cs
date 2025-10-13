using Anycraft.Features.Configs.Table;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemsTagsTableConfig))]
    public sealed class ItemsTagsTableConfig : BaseTableConfig<ItemTagConfig>
    {
        public override void Validate()
        {
        }
    }
}