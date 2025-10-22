using Anycraft.Features.SceneScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneBootstrap) + "/" + nameof(BootstrapSceneScriptStarterScriptableInstaller))]
    public sealed class BootstrapSceneScriptStarterScriptableInstaller
        : BaseSceneScriptStarterScriptableInstaller<BootstrapSceneScriptStarter, BootstrapSceneScript>
    {
    }
}