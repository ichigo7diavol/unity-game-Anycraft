using Anycraft.Features.Logger;
using Anycraft.Features.SceneScripting;
using Anycraft.Features.Ui;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine.Assertions;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapSceneScript
        : BaseSceneScript, ISceneScriptStartable
    {
        private readonly IPublisher<ShowPopupEvent<BootstrapPopupPresenter,
            BootstrapPopupPresenter.Data>> _showBootstrapPopupPublisher;

        public BootstrapSceneScript
        (
            IPublisher<ShowPopupEvent<BootstrapPopupPresenter,
                BootstrapPopupPresenter.Data>> showBootstrapPopupPublisher
        )
        {
            Assert.IsNotNull(showBootstrapPopupPublisher);

            _showBootstrapPopupPublisher = showBootstrapPopupPublisher;
        }

        public async UniTask StartAsync()
        {
            this.LogStepStarted("execution");

            this.LogStepStarted($"opening: {nameof(BootstrapPopupPresenter)}");

            await UniTask.WaitForSeconds(1);

            var progressObservale = new ReactiveProperty<float>();
            var popupData = new BootstrapPopupPresenter.Data(progressObservale);
            var eventData = new ShowPopupEvent
            <
                BootstrapPopupPresenter,
                BootstrapPopupPresenter.Data
            >(popupData);

            _showBootstrapPopupPublisher.Publish(eventData);

            this.LogStepCompleted($"opened: {nameof(BootstrapPopupPresenter)}");
            
            this.LogStepCompleted("execution");
        }
    }
}