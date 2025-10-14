using Anycraft.FluentValidationExtensions.Tags.Configs;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Resource.Configs
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceTagConfig))]
    public sealed partial class ResourceTagConfig
        : BaseTagConfig
    {
    }
}