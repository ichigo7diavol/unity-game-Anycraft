using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anycraft.Features.Processor
{
    [Serializable]
    public sealed partial class ProcessorOutputData
    {
        [SerializeField] private List<ProcessorItemSlotData> _itemSlot;
        [SerializeField] private List<ProcessorResourceSlotData> _resourceSlot;

        public IReadOnlyList<ProcessorItemSlotData> ItemSlot => _itemSlot;
        public IReadOnlyList<ProcessorResourceSlotData> ResourceSlot => _resourceSlot;
    }
}

