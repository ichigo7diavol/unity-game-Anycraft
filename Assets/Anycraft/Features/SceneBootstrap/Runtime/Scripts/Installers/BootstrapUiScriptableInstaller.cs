using Anycraft.Features.Ui;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneBootstrap) + "/" + nameof(BootstrapUiScriptableInstaller))]
    public sealed class BootstrapUiScriptableInstaller
        : BaseUiScriptableInstaller<BootstrapPopupsMediator>
    {
    }
}
