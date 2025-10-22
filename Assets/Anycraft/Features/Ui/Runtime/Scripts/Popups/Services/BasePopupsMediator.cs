using UnityEngine.Assertions;
using JetBrains.Annotations;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupsMediator
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly PopupsService _service;

        public CancellationToken Token => _cts.Token;

        protected PopupsService Service => _service;

        protected BasePopupsMediator(PopupsService service)
        {
            Assert.IsNotNull(service);

            _service = service;
        }

        protected void OnShowPopup<TPopupPresenter>(ShowPopupEvent<TPopupPresenter> _)
            where TPopupPresenter : BasePopupPresenter
        {
            Service.ShowPopupAsync<TPopupPresenter>().Forget();
        }

        protected void OnShowPopup<TPopupPresenter, TPopupData>(ShowPopupEvent<TPopupPresenter, TPopupData> data)
            where TPopupPresenter : BasePopupPresenter<TPopupData>
            where TPopupData : class
        {
            Service.ShowPopupAsync<TPopupPresenter, TPopupData>(data.PopupData).Forget();
        }

        protected void OnHidePopup<TPopupPresenter>(HidePopupEvent<TPopupPresenter> _)
            where TPopupPresenter : BasePopupPresenter
        {
            Service.HidePopupAsync<TPopupPresenter>().Forget();
        }
    } 
}