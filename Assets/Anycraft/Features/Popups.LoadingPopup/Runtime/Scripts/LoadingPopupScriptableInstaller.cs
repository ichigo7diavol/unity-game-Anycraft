using Anycraft.Features.Frame.Frame.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Popups.LoadingPopup
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Popups) + "/" + nameof(LoadingPopup) + "/" + nameof(LoadingPopupScriptableInstaller))]
    public sealed class LoadingPopupScriptableInstaller
        : BasePopupScriptableInstaller<LoadingPopupPresenter>
    {
    }
}