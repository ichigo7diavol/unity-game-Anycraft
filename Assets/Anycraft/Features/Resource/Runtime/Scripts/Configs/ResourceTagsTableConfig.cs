using Anycraft.Features.Configs.Table;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Resource.Configs
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceTagsTableConfig))]
    public sealed partial class ResourceTagsTableConfig
        : BaseTableConfig<ResourceTagConfig>
    {
    }
}