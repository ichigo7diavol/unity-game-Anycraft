using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine.Assertions;
using Anycraft.Features.Frame.Ui;
using Anycraft.Features.Popups.LoadingPopup;
using UnityEngine;

namespace Anycraft.Features.Scenes.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapPopupsMediator
        : BasePopupsServiceMediator
    {
        public BootstrapPopupsMediator
        (
            PopupsService popupsService,
            IAsyncSubscriber<ShowPopupEvent<LoadingPopupPresenter,
                LoadingPopupPresenter.Data>> showBootstrapPopupPublisher
        )
            : base(popupsService)
        {
            Assert.IsNotNull(showBootstrapPopupPublisher);

            showBootstrapPopupPublisher
                .Subscribe(OnShowPopup)
                .AddTo(Token);
        }
    }
}