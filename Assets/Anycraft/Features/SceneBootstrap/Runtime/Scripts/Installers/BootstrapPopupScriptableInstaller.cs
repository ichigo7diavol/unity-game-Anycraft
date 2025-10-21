using Anycraft.Features.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneBootstrap) + "/" + nameof(GlobalUiScriptableInstaller))]
    public sealed class GlobalUiScriptableInstaller
        : BasePopupScriptableInstaller<BootstrapPopupPresenter>
    {
    }
}