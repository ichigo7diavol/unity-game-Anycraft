using Anycraft.Features.Ui.Popups.Installers;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneBootstrap) + "/" + nameof(BootstrapPopupScriptableInstaller))]
    public sealed class BootstrapPopupScriptableInstaller
        : BasePopupScriptableInstaller<BootstrapPopupPresenter>
    {
    }
}