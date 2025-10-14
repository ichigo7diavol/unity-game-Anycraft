using Anycraft.FluentValidationExtensions.Configs.Table;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Items.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Items) + "/" + nameof(Configs) + "/" + nameof(ItemsTableConfig))]
    public sealed partial class ItemsTableConfig
        : BaseTableConfig<ItemConfig>
    {
    }
}