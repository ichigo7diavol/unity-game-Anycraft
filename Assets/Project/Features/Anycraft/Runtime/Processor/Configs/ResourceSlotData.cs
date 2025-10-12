using System;
using Anycraft.Frame.Localization;
using UnityEngine;

namespace Anycraft.Processor
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

