using UnityEngine.Assertions;
using JetBrains.Annotations;
using System.Threading;
using Cysharp.Threading.Tasks;
using Anycraft.Features.Ui.Popups.Presenters;

namespace Anycraft.Features.Ui.Popups.Services
{
    [UsedImplicitly]
    public abstract class BasePopupsMediator
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly PopupsService _popupsService;

        public CancellationToken Token => _cts.Token;

        protected PopupsService PopupsService => _popupsService;

        protected BasePopupsMediator(PopupsService popupsService)
        {
            Assert.IsNotNull(popupsService);

            _popupsService = popupsService;
        }

        protected async UniTask OnShowPopup<TPopupPresenter>
        (
            ShowPopupEvent<TPopupPresenter> data,
            CancellationToken token
        )
            where TPopupPresenter : BasePopupPresenter
        {
            await PopupsService.ShowAsync<TPopupPresenter>();
        }

        protected async UniTask OnShowPopup<TPopupPresenter, TPopupData>
        (
            ShowPopupEvent<TPopupPresenter, TPopupData> data,
            CancellationToken token
        )
            where TPopupPresenter : BasePopupPresenter<TPopupData>
            where TPopupData : BasePopupPresenter
        {
            var presenter = await PopupsService.ShowAsync<TPopupPresenter>();
            presenter.Data = data.PopupData;
        }
    } 
}