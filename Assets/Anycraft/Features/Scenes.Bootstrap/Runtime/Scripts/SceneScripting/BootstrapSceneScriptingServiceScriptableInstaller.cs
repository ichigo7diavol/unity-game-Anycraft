using Anycraft.Features.Frame.Services.SceneScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Scenes.SceneBootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneBootstrap) + "/" + nameof(BootstrapSceneScriptingServiceScriptableInstaller))]
    public sealed class BootstrapSceneScriptingServiceScriptableInstaller
        : BaseSceneScriptingServiceScriptableInstaller<BootstrapSceneScript>
    {
    }
}