using JetBrains.Annotations;
using System;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public readonly struct ShowPopupEvent<TPopupPreesnter>
        where TPopupPreesnter : BasePopupPresenter
    {
        public readonly Type PopupType => typeof(TPopupPreesnter);
    }

    [UsedImplicitly]
    public readonly struct ShowPopupEvent<TPopupPreesnter, TPopupData>
        where TPopupPreesnter : BasePopupPresenter<TPopupData>
        where TPopupData : class
    {
        public readonly TPopupData PopupData;

        public ShowPopupEvent(TPopupData data)
        {
            PopupData = data;
        }
    }

    [UsedImplicitly]
    public readonly struct HidePopupEvent<TPopupPreesnter>
        where TPopupPreesnter : BasePopupPresenter
    {
        public readonly Type PopupType => typeof(TPopupPreesnter);
    }
}