using JetBrains.Annotations;
using System;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public readonly struct ShowPopupEvent<TPopupPreesnter>
        where TPopupPreesnter : BasePopupPresenter
    {
        public readonly Type PopupType => typeof(TPopupPreesnter);
        public readonly bool IsInstant;

        public ShowPopupEvent(bool isInstant = false)
        {
            IsInstant = isInstant;
        }
    }

    [UsedImplicitly]
    public readonly struct ShowPopupEvent<TPopupPreesnter, TPopupData>
        where TPopupPreesnter : BasePopupPresenter<TPopupData>
        where TPopupData : class
    {
        public readonly TPopupData PopupData;
        public readonly bool IsInstant;

        public ShowPopupEvent(TPopupData data, bool isInstant = false)
        {
            PopupData = data;
            IsInstant = isInstant;
        }
    }

    [UsedImplicitly]
    public readonly struct HidePopupEvent<TPopupPreesnter>
        where TPopupPreesnter : BasePopupPresenter
    {
        public readonly Type PopupType => typeof(TPopupPreesnter);
        public readonly bool IsInstant;

        public HidePopupEvent(bool isInstant = false)
        {
            IsInstant = isInstant;
        }
    }
}