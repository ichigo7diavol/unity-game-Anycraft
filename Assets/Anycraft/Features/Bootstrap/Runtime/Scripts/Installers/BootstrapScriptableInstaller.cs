using Anycraft.Features.Ui.Popups.Services;
using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Bootstrap.Installers
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Bootstrap) + "/" + nameof(Installers) + "/" + nameof(BootstrapScriptableInstaller))]
    public sealed class BootstrapScriptableInstaller
        : BaseScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.RegisterMessageBroker<ShowPopupEvent<BootstrapPopupPresenter>>(
                new MessagePipeOptions());
        }
    }
}
