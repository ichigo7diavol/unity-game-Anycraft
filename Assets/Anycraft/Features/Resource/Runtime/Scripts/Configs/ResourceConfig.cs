using Anycraft.Features.Configs;
using UnityEngine;

namespace Anycraft.Features.Resource.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Features/Resource/" + nameof(ResourceConfig))]
    public sealed partial class ResourceConfig
        : BaseSerializedConfig
    {
    }
}