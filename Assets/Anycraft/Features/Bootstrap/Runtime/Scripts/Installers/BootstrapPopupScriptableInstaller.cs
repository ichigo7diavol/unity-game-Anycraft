using Anycraft.Features.Bootstrap.Ui;
using Anycraft.Features.Ui.Popups.Presenters.Installers;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Bootstrap.Installers
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Bootstrap) + "/" + nameof(BootstrapPopupScriptableInstaller))]
    public sealed class BootstrapPopupScriptableInstaller
        : BasePopupScriptableInstaller<BootstrapPopupPresenter>
    {
    }
}