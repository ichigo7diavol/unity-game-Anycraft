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
            ISubscriber<SceneLoadingStartedEvent> sceneLoadingStartedSubscriber,
            ISubscriber<SceneLoadingCompletedEvent> sceneLoadingCompletedSubscriber
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

        private void OnSceneLoadingStarted(SceneLoadingStartedEvent eventData)
        {
            var data = new LoadingPopupPresenter.Data(eventData.ProgressObservable);

            OnShowPopup(new ShowPopupEvent<LoadingPopupPresenter, LoadingPopupPresenter.Data>(data));
        }

        private void OnSceneLoadedCompleted(SceneLoadingCompletedEvent eventData)
        {
            OnHidePopup(new HidePopupEvent<LoadingPopupPresenter>());
        }
    }
}