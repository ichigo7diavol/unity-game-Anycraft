using Anycraft.Features.Frame.Frame.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Popups.BootstrapPopup
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Popups) + "/" + nameof(BootstrapPopup) + "/" + nameof(BootstrapPopupScriptableInstaller))]
    public sealed class BootstrapPopupScriptableInstaller
        : BasePopupScriptableInstaller<BootstrapPopupPresenter>
    {
    }
}