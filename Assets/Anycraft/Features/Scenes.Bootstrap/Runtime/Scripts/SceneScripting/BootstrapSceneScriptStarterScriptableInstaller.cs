using Anycraft.Features.Frame.Services.SceneScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Scenes.Bootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Scenes) + "/" + nameof(Bootstrap) + "/" + nameof(BootstrapSceneScriptStarterScriptableInstaller))]
    public sealed class BootstrapSceneScriptStarterScriptableInstaller
        : BaseSceneScriptStarterScriptableInstaller<BootstrapSceneScriptStarter, BootstrapSceneScript>
    {
    }
}