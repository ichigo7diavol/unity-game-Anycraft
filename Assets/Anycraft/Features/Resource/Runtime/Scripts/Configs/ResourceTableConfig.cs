using Anycraft.FluentValidationExtensions.Configs.Table;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Resource.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceTableConfig))]
    public sealed partial class ResourceTableConfig
        : BaseTableConfig<ResourceConfig>
    {
    }
}