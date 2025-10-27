using UnityEngine.Assertions;
using JetBrains.Annotations;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupsServiceMediator
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly PopupsService _service;

        public CancellationToken Token => _cts.Token;

        protected PopupsService Service => _service;

        protected BasePopupsServiceMediator(PopupsService service)
        {
            Assert.IsNotNull(service);

            _service = service;
        }

        protected async UniTask OnShowPopup<TPopupPresenter>
        (
            ShowPopupEvent<TPopupPresenter> data,
            CancellationToken token = default
        )
            where TPopupPresenter : BasePopupPresenter
        {
            await Service.ShowPopupAsync<TPopupPresenter>(data.IsInstant);
        }

        protected async UniTask OnShowPopup<TPopupPresenter, TPopupData>
        (
            ShowPopupEvent<TPopupPresenter, TPopupData> data,
            CancellationToken token = default
        )
            where TPopupPresenter : BasePopupPresenter<TPopupData>
            where TPopupData : class
        {
            await Service.ShowPopupAsync<TPopupPresenter, TPopupData>(data.PopupData, data.IsInstant);
        }

        protected async UniTask OnHidePopup<TPopupPresenter>
        (
            HidePopupEvent<TPopupPresenter> data,
            CancellationToken token = default
        )
            where TPopupPresenter : BasePopupPresenter
        {
            await Service.HidePopupAsync<TPopupPresenter>(data.IsInstant);
        }
    } 
}