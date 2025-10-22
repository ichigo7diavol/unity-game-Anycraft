using UnityEngine;
using JetBrains.Annotations;
using Anycraft.Features.Frame.Configs;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Ui) + "/" + nameof(PopupsServiceConfig))]
    public sealed partial class PopupsServiceConfig
        : BaseSerializedConfig
    {
    }
}