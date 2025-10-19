using Anycraft.Features.Ui.Popups.Presenters;
using JetBrains.Annotations;
using System;

namespace Anycraft.Features.Ui.Popups.Services
{
    [UsedImplicitly]
    public readonly struct ShowPopupEvent<TPopupPreesnter>
        where TPopupPreesnter : BasePopupPresenter
    {
        public readonly Type PopupType => typeof(TPopupPreesnter);
    }

    [UsedImplicitly]
    public readonly struct ShowPopupEvent<TPopupPreesnter, TData>
        where TPopupPreesnter : BasePopupPresenter<TData>
    {
        public readonly TData PopupData;

        public ShowPopupEvent(TData data)
        {
            PopupData = data;
        }
    }
}