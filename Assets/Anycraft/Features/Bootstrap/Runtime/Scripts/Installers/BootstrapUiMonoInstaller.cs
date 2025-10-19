using Anycraft.Features.Bootstrap.Popups;
using Anycraft.Features.Ui.Popups.Presenters.Installers;
using Anycraft.Features.Ui.Popups.Services;
using JetBrains.Annotations;
using MessagePipe;
using VContainer;

namespace Anycraft.Features.Bootstrap.Installers
{
    [UsedImplicitly]
    public sealed class BootstrapUiMonoInstaller
        : BaseUiMonoInstaller<BootstrapPopupsMediator>
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.RegisterMessageBroker<ShowPopupEvent<BootstrapPopupPresenter>>(
                new MessagePipeOptions());
        }
    }
}
