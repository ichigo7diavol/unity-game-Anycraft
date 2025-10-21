using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine.Assertions;
using Anycraft.Features.Ui;
using UnityEngine;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapPopupsMediator
        : BasePopupsMediator
    {
        public BootstrapPopupsMediator
        (
            PopupsService popupsService,
            ISubscriber<ShowPopupEvent<BootstrapPopupPresenter>> showBootstrapPopupPublisher
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