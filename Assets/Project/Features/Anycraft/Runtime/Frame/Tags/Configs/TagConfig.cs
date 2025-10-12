using System;
using UnityEngine;
using Anycraft.Frame.Localization;
using Anycraft.Frame.Configs;

namespace Anycraft.Frame.Tags.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Frame/Tags/Configs/" + nameof(TagConfig))]
    public class TagConfig : SerializedConfig
    {
        [Serializable]
        public sealed class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private LocalizationData _localization;

        public LocalizationData Localization { get => _localization; }

        public override string ToString() => $"Tag--{Id}"; 
    }
}

