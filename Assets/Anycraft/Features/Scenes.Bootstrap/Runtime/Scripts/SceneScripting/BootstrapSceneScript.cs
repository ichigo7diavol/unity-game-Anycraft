using Anycraft.Features.Frame.Logger;
using Anycraft.Features.Frame.Services.SceneLoader;
using Anycraft.Features.Frame.Services.SceneScripting;
using Anycraft.Features.Frame.Ui;
using Anycraft.Features.Popups.LoadingPopup;
using Anycraft.Features.Scenes.Main;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anycraft.Features.Scenes.Bootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapSceneScript
        : BaseSceneScript, ISceneScriptStartable
    {
        private readonly IAsyncPublisher<ShowPopupEvent<LoadingPopupPresenter,
            LoadingPopupPresenter.Data>> _showBootstrapPopupPublisher;
        private readonly IPublisher<LoadSceneEvent<MainSceneScript>> _loadSceneMenuPublisher;

        public BootstrapSceneScript
        (
            IAsyncPublisher<ShowPopupEvent<LoadingPopupPresenter,
                LoadingPopupPresenter.Data>> showBootstrapPopupPublisher,
            IPublisher<LoadSceneEvent<MainSceneScript>> loadSceneMenuPublisher
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

            this.LogStepStarted($"opening: {nameof(LoadingPopupPresenter)}");

            await UniTask.WaitForSeconds(1);

            using var progressObservale = new ReactiveProperty<float>();
            using var bottomTextObservale = new ReactiveProperty<string>("LOADING");
            
            RaiseShowLoadingPopup(bottomTextObservale, progressObservale);

            this.LogStepCompleted($"opening: {nameof(LoadingPopupPresenter)}");

            var duration = 1.0f;
            var t = 0.0f;

            while (t < duration)
            {
                t += Time.unscaledDeltaTime;
                progressObservale.Value = t;

                await UniTask.NextFrame();
            }
            bottomTextObservale.Value = "READY";
            _loadSceneMenuPublisher.Publish(
                new LoadSceneEvent<MainSceneScript>());

            this.LogStepCompleted("execution");
        }

        private void RaiseShowLoadingPopup
        (
            ReadOnlyReactiveProperty<string> bottomTextObservale,
            ReadOnlyReactiveProperty<float> progressObservale
        )
        {
            var popupData = new LoadingPopupPresenter.Data
            (
                "Bootstrap",
                bottomTextObservale,
                progressObservale
            );
            var eventData = new ShowPopupEvent
            <
                LoadingPopupPresenter,
                LoadingPopupPresenter.Data
            >(popupData, true);

            _showBootstrapPopupPublisher.Publish(eventData);
        }
    }
}