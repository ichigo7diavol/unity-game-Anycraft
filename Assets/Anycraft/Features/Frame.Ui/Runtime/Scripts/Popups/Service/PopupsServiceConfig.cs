using UnityEngine;
using JetBrains.Annotations;
using Anycraft.Features.Configs;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Ui) + "/" + nameof(PopupsServiceConfig))]
    public sealed partial class PopupsServiceConfig
        : BaseSerializedConfig
    {
    }
}