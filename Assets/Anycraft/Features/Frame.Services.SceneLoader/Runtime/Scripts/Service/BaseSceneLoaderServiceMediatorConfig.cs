using Anycraft.Features.Frame.Configs;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Frame.Services.SceneLoader
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneLoader) + "/" + nameof(BaseSceneLoaderServiceMediatorConfig))]
    public abstract class BaseSceneLoaderServiceMediatorConfig
        : BaseSerializedConfig
    {
    }
}