using System;
using UnityEngine;

namespace Anycraft.Features.Configs.Index
{
    [Serializable]
    public abstract partial class BaseIndexTableEntry<TTable, TConfig>
        where TTable : BaseIndexTableConfig<TConfig>
        where TConfig : BaseIndexedConfig
    {
        [SerializeField] private int _index;

        public int Index => _index; 
    }
}