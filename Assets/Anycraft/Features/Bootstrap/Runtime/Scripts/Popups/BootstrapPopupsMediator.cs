using Anycraft.Features.Ui.Popups.Services;
using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine.Assertions;

namespace Anycraft.Features.Bootstrap.Popups
{
    [UsedImplicitly]
    public sealed class BootstrapPopupsMediator
        : BasePopupsMediator
    {
        public BootstrapPopupsMediator
        (
            PopupsService popupsService,
            IAsyncSubscriber<ShowPopupEvent<BootstrapPopupPresenter>> showBootstrapPopupPublisher
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