using Anycraft.Features.Ui.Popups.Installers;
using JetBrains.Annotations;
using VContainer;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapUiMonoInstaller
        : BaseUiMonoInstaller<BootstrapPopupsMediator>
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
        }
    }
}
