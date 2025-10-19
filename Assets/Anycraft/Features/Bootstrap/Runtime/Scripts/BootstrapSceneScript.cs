using Anycraft.Features.Bootstrap;
using Anycraft.Features.Bootstrap.Installers;
using Anycraft.Features.SceneScripting;
using Anycraft.Features.Ui.Popups.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using NUnit.Framework;

namespace Anycraft.Features.Bootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapSceneScript
        : BaseSceneScript
    {
        private readonly IAsyncPublisher<ShowPopupEvent<BootstrapPopupPresenter>> _showBootstrapPopupPublisher;

        public BootstrapSceneScript
        (
            IAsyncPublisher<ShowPopupEvent<BootstrapPopupPresenter>> showBootstrapPopupPublisher
        )
        {
            Assert.IsNotNull(showBootstrapPopupPublisher);

            _showBootstrapPopupPublisher = showBootstrapPopupPublisher;
        }

        public override UniTask StartAsync()
        {
            _showBootstrapPopupPublisher
                .Publish(new ShowPopupEvent<BootstrapPopupPresenter>());

            return UniTask.CompletedTask;
        }
    }
}