using Anycraft.FluentValidationExtensions.Configs.Table;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Resource.Configs
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceTagsTableConfig))]
    public sealed partial class ResourceTagsTableConfig
        : BaseTableConfig<ResourceTagConfig>
    {
    }
}