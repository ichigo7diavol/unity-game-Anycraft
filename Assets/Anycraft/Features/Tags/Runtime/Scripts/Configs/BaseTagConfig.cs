using System;
using Anycraft.Features.Configs;
using Anycraft.Features.Localization;
using UnityEngine;

namespace Anycraft.Features.Tags.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Frame/Tags/Configs/" + nameof(BaseTagConfig))]
    public abstract class BaseTagConfig : BaseSerializedConfig
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

