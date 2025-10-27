using Anycraft.Features.Frame.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Scenes.Main
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Scenes) + "/" + nameof(Main) + "/" + nameof(MainUiScriptableInstaller))]
    public sealed class MainUiScriptableInstaller
        : BaseUiScriptableInstaller<MainUiPopupsMediator>
    {
    }
}