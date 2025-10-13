using System;
using Anycraft.Features.Configs;
using Anycraft.Features.Localization;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemConfig))]
    public sealed class ItemConfig : BaseSerializedConfig
    {
        [Serializable]
        public sealed class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private ItemTagTableEntries _tags;
    }
}

