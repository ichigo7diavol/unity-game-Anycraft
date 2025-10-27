using Anycraft.Features.Frame.Ui;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Scenes.Bootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Scenes) + "/" + nameof(Bootstrap) + "/" + nameof(BootstrapUiScriptableInstaller))]
    public sealed class BootstrapUiScriptableInstaller
        : BaseUiScriptableInstaller<BootstrapPopupsMediator>
    {
    }
}
