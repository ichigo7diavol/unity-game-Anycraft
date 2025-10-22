using Anycraft.Features.Frame.Logger;
using Anycraft.Features.Frame.Services.SceneLoader;
using Anycraft.Features.Frame.Services.SceneScripting;
using Anycraft.Features.Frame.Ui;
using Anycraft.Features.Popups.LoadingPopup;
using Anycraft.Features.Scenes.SceneMenu;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anycraft.Features.Scenes.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapSceneScript
        : BaseSceneScript, ISceneScriptStartable
    {
        private readonly IPublisher<ShowPopupEvent<LoadingPopupPresenter,
            LoadingPopupPresenter.Data>> _showBootstrapPopupPublisher;
        private readonly IPublisher<LoadSceneEvent<MenuSceneScript>> _loadSceneMenuPublisher;

        public BootstrapSceneScript
        (
            IPublisher<ShowPopupEvent<LoadingPopupPresenter,
                LoadingPopupPresenter.Data>> showBootstrapPopupPublisher,
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

            this.LogStepStarted($"opening: {nameof(LoadingPopupPresenter)}");

            await UniTask.WaitForSeconds(1);

            var progressObservale = new ReactiveProperty<float>();
            var bottomTextObservale = new ReactiveProperty<string>("LOADING");
            
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
                new LoadSceneEvent<MenuSceneScript>());

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
            >(popupData);

            _showBootstrapPopupPublisher.Publish(eventData);
        }
    }
}