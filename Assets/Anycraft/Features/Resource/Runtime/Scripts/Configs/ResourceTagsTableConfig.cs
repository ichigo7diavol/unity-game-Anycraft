using Anycraft.Features.Configs.Table;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Resource.Configs
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = "Anycraft/Features/Resource/" + nameof(ResourceTagsTableConfig))]
    public sealed partial class ResourceTagsTableConfig
        : BaseTableConfig<ResourceTagConfig>
    {
    }
}