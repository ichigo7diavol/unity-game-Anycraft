using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine.Assertions;
using Anycraft.Features.Frame.Ui;
using Anycraft.Features.Popups.LoadingPopup;

namespace Anycraft.Features.Scenes.Bootstrap
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