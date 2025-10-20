using Anycraft.Features.Tags.Configs;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Resource
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceTagConfig))]
    public sealed partial class ResourceTagConfig
        : BaseTagConfig
    {
    }
}