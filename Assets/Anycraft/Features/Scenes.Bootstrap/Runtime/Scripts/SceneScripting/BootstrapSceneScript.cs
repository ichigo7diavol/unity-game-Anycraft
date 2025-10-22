using Anycraft.Features.BootstrapPopup;
using Anycraft.Features.Logger;
using Anycraft.Features.SceneLoader;
using Anycraft.Features.SceneMenu;
using Anycraft.Features.SceneScripting;
using Anycraft.Features.Ui;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapSceneScript
        : BaseSceneScript, ISceneScriptStartable
    {
        private readonly IPublisher<ShowPopupEvent<BootstrapPopupPresenter,
            BootstrapPopupPresenter.Data>> _showBootstrapPopupPublisher;
        private readonly IPublisher<LoadSceneEvent<MenuSceneScript>> _loadSceneMenuPublisher;

        public BootstrapSceneScript
        (
            IPublisher<ShowPopupEvent<BootstrapPopupPresenter,
                BootstrapPopupPresenter.Data>> showBootstrapPopupPublisher,
            IPublisher<LoadSceneEvent<MenuSceneScript>> loadSceneMenuPublisher
        )
        {
            Assert.IsNotNull(showBootstrapPopupPublisher);
            Assert.IsNotNull(loadSceneMenuPublisher);

            _showBootstrapPopupPublisher = showBootstrapPopupPublisher;
            _loadSceneMenuPublisher = loadSceneMenuPublisher;
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

            this.LogStepCompleted($"opening: {nameof(BootstrapPopupPresenter)}");

            var duration = 1.0f;
            var t = 0.0f;

            while (t < duration)
            {
                t += Time.unscaledDeltaTime;
                progressObservale.Value = t;

                await UniTask.NextFrame();
            }
            _loadSceneMenuPublisher.Publish(new LoadSceneEvent<MenuSceneScript>());

            this.LogStepCompleted("execution");
        }
    }
}