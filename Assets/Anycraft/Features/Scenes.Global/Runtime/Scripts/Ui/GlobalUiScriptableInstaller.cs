using Anycraft.Features.Frame.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Scenes.Global
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Scenes) + "/" + nameof(Global) + "/" + nameof(GlobalUiScriptableInstaller))]
    public sealed class GlobalUiScriptableInstaller
        : BaseUiScriptableInstaller<GlobalUiPopupsMediator>
    {
    }
}