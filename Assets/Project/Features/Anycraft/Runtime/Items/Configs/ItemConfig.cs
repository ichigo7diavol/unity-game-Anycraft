using System;
using Anycraft.Frame.Configs;
using Anycraft.Frame.Localization;
using UnityEngine;

namespace Anycraft.Items.Configs
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

