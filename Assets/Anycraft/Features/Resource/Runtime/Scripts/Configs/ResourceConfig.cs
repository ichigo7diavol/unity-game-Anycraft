using Anycraft.FluentValidationExtensions.Configs;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Resource.Configs
{

    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Resource) + "/" + nameof(Configs) + "/" + nameof(ResourceConfig))]
    public sealed partial class ResourceConfig
        : BaseSerializedConfig
    {
    }
}