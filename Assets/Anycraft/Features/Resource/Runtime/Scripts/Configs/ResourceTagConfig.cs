using Anycraft.Features.Tags.Configs;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Resource.Configs
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = "Anycraft/Features/Resource/" + nameof(ResourceTagConfig))]
    public sealed partial class ResourceTagConfig
        : BaseTagConfig
    {
    }
}