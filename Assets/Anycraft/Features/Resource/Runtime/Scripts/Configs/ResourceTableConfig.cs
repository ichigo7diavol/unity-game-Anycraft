using Anycraft.Features.Configs.Table;
using UnityEngine;

namespace Anycraft.Features.Resource
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceTableConfig))]
    public sealed partial class ResourceTableConfig
        : BaseTableConfig<ResourceConfig>
    {
    }
}