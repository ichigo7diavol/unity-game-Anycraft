using UnityEngine;
using JetBrains.Annotations;
using Anycraft.Features.Configs;
using System.Collections.Generic;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Ui) + "/" + nameof(PopupsServiceConfig))]
    public sealed partial class PopupsServiceConfig
        : BaseSerializedConfig
    {
        [SerializeField] private List<BasePopupPresenter> _popupsPrefabs = new();

        public IReadOnlyList<BasePopupPresenter> PopupsPrefabs => _popupsPrefabs;
    }
}