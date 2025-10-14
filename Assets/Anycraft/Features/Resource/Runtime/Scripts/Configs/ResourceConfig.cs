using Anycraft.Features.Configs;
using UnityEngine;

namespace Anycraft.Features.Resource.Configs
{

    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceConfig))]
    public sealed partial class ResourceConfig
        : BaseSerializedConfig
    {
    }
}