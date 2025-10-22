using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine.Assertions;
using Anycraft.Features.Ui;
using Anycraft.Features.BootstrapPopup;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapPopupsMediator
        : BasePopupsServiceMediator
    {
        public BootstrapPopupsMediator
        (
            PopupsService popupsService,
            ISubscriber<ShowPopupEvent<BootstrapPopupPresenter,
                BootstrapPopupPresenter.Data>> showBootstrapPopupPublisher
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