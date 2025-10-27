using System.Threading;
using Anycraft.Features.Frame.Services.SceneLoader;
using Anycraft.Features.Frame.Ui;
using Anycraft.Features.Popups.LoadingPopup;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine.Assertions;

namespace Anycraft.Features.Scenes.Global
{
    [UsedImplicitly]
    public sealed class GlobalUiPopupsMediator
        : BasePopupsServiceMediator
    {
        public GlobalUiPopupsMediator
        (
            PopupsService popupsService,
            IAsyncSubscriber<SceneLoadingStartedEvent> sceneLoadingStartedSubscriber,
            IAsyncSubscriber<SceneLoadingCompletedEvent> sceneLoadingCompletedSubscriber
        )
            : base(popupsService)
        {
            Assert.IsNotNull(sceneLoadingStartedSubscriber);
            Assert.IsNotNull(sceneLoadingCompletedSubscriber);

            sceneLoadingStartedSubscriber
                .Subscribe(OnSceneLoadingStarted)
                .AddTo(Token);

            sceneLoadingCompletedSubscriber
                .Subscribe(OnSceneLoadedCompleted)
                .AddTo(Token);
        }

        private async UniTask OnSceneLoadingStarted
        (
            SceneLoadingStartedEvent eventData,
            CancellationToken token = default
        )
        {
            // todo: decouple ui and scene loading things
            var data = new LoadingPopupPresenter.Data
            (
                eventData.LoadingPopupHeaderText,
                eventData.LoadingPopupBottomTextxObservable,
                eventData.ProgressObservable
            );
            await OnShowPopup(new ShowPopupEvent<LoadingPopupPresenter, LoadingPopupPresenter.Data>(data));
        }

        private async UniTask OnSceneLoadedCompleted
        (
            SceneLoadingCompletedEvent eventData,
            CancellationToken token = default
        )
        {
            await OnHidePopup(new HidePopupEvent<LoadingPopupPresenter>());
        }
    }
}