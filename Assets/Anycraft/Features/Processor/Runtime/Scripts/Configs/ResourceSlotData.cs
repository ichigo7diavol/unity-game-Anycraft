using System;
using Anycraft.Features.Localization;
using UnityEngine;

namespace Anycraft.Features.Processor
{
    [Serializable]
    public sealed class ProcessorResourceSlotData
    {
        public class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private LocalizationData _localization;
    
        public LocalizationData Localization => _localization;
    }
}

