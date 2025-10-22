using Anycraft.Features.Frame.Frame.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Popups.MenuPopup
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Popups) + "/" + nameof(MenuPopup) + "/" + nameof(MenuPopupScriptableInstaller))]
    public sealed class MenuPopupScriptableInstaller
        : BasePopupScriptableInstaller<MenuPopupPresenter>
    {
    }
}