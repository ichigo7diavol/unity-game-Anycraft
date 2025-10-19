using Anycraft.Features.SceneScripting;
using Anycraft.Features.Ui.Popups.Services;
using JetBrains.Annotations;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Bootstrap.Installers
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Bootstrap) + "/" + nameof(Installers) + "/" + nameof(BootstrapSceneScriptingServiceInstaller))]
    public sealed class BootstrapSceneScriptingServiceInstaller
        : BaseSceneScriptingServiceScriptableInstaller<BootstrapSceneScript>
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
        }
    }
}