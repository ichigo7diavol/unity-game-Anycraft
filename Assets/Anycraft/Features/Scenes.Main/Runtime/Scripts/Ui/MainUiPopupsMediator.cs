using System.Threading;
using Anycraft.Features.Frame.Services.SceneLoader;
using Anycraft.Features.Frame.Ui;
using Anycraft.Features.Popups.LoadingPopup;
using Anycraft.Features.Popups.MenuPopup;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine.Assertions;

namespace Anycraft.Features.Scenes.Main
{
    [UsedImplicitly]
    public sealed class MainUiPopupsMediator
        : BasePopupsServiceMediator
    {
        public MainUiPopupsMediator
        (
            PopupsService popupsService,
            IAsyncSubscriber<ShowPopupEvent<MenuPopupPresenter>> showMenuPopupSubscriber
        )
            : base(popupsService)
        {
            Assert.IsNotNull(showMenuPopupSubscriber);

            showMenuPopupSubscriber
                .Subscribe(OnShowPopup)
                .AddTo(Token);
        }
    }
}