using System;
using Anycraft.FluentValidationExtensions.Configs.Table;

namespace Anycraft.FluentValidationExtensions.Items.Configs
{
    [Serializable]
    public sealed class ItemTagTableEntries
        : BaseTableEntries<ItemsTagsTableConfig, ItemTagConfig>
    { }
}

