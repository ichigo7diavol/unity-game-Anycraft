using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Processor.Configs
{
    [Serializable]
    public sealed partial class ProcessorInputData
    {
        [SerializeField] private List<ProcessorItemSlotData> _itemSlot;
        [SerializeField] private List<ProcessorResourceSlotData> _resourceSlot;

        public IReadOnlyList<ProcessorItemSlotData> ItemSlot => _itemSlot;
        public IReadOnlyList<ProcessorResourceSlotData> ResourceSlot => _resourceSlot;
    }
}

