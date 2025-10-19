using Anycraft.Features.SceneScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Bootstrap.Installers
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Bootstrap) + "/" + nameof(BootstrapSceneScriptingServiceInstaller))]
    public sealed class BootstrapSceneScriptingServiceInstaller
        : BaseSceneScriptingServiceScriptableInstaller<BootstrapSceneScript>
    {
    }
}