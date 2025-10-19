using Anycraft.Features.Bootstrap.Ui;
using Anycraft.Features.Logger;
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

        public override async UniTask StartAsync()
        {
            this.LogStepStarted("execution");

            this.LogStepStarted($"opening: {nameof(BootstrapPopupPresenter)}");

            await _showBootstrapPopupPublisher
                .PublishAsync(new ShowPopupEvent<BootstrapPopupPresenter>());

            this.LogStepCompleted($"opened: {nameof(BootstrapPopupPresenter)}");
            
            this.LogStepCompleted("execution");
        }
    }
}