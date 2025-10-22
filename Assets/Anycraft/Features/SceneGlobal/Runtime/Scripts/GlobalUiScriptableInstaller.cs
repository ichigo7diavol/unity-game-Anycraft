using Anycraft.Features.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Global
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Global) + "/" + nameof(GlobalUiScriptableInstaller))]
    public sealed class GlobalUiScriptableInstaller
        : BaseUiScriptableInstaller<GlobalUiPopupsMediator>
    {
    }
}