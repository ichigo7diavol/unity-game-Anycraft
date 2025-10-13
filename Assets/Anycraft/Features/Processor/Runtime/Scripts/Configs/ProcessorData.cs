using Anycraft.Features.Localization;
using UnityEngine;

namespace Anycraft.Features.Processor.Configs
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

