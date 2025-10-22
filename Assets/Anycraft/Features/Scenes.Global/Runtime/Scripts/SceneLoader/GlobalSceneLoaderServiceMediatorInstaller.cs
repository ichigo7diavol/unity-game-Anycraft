using Anycraft.Features.Frame.Services.SceneLoader;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Scenes.Global
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Global) + "/" + nameof(GlobalSceneLoaderServiceMediatorInstaller))]
    public sealed class GlobalSceneLoaderServiceMediatorInstaller
        : BaseSceneLoaderServiceMediatorInstaller<
            GlobalSceneLoaderServiceMediator, GlobalSceneLoaderServiceMediatorConfig>
    {
    }
}