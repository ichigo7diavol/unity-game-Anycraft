using Anycraft.Frame.Localization;
using UnityEngine;

namespace Anycraft.Processor.Configs
{
    public sealed class ProcessorData
    {
        public class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private LocalizationData _localization;

        [SerializeField] private int _processingTime;
        
        public LocalizationData Localization => _localization;
    }
}

