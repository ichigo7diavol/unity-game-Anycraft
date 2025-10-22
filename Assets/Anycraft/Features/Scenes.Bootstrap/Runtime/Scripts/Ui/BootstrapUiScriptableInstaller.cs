using Anycraft.Features.Frame.Ui;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Scenes.SceneBootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Scenes) + "/" + nameof(SceneBootstrap) + "/" + nameof(BootstrapUiScriptableInstaller))]
    public sealed class BootstrapUiScriptableInstaller
        : BaseUiScriptableInstaller<BootstrapPopupsMediator>
    {
    }
}
