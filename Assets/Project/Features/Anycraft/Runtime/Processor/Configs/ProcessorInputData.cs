using System;
using System.Collections.Generic;
using Anycraft.Frame.Localization;
using UnityEngine;

namespace Anycraft.Processor.Configs
{
    [Serializable]
    public sealed class ProcessorInputData
    {
        public class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private LocalizationData _localization;

        [SerializeField] private List<ProcessorItemSlotData> _itemSlot;
        [SerializeField] private List<ProcessorResourceSlotData> _resourceSlot;

        public LocalizationData Localization => _localization;

        public IReadOnlyList<ProcessorItemSlotData> ItemSlot => _itemSlot;
        public IReadOnlyList<ProcessorResourceSlotData> ResourceSlot => _resourceSlot;
    }
}

