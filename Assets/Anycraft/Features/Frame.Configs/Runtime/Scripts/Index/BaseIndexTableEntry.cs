using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs
{
    [Serializable]
    [UsedImplicitly]
    public abstract partial class BaseIndexTableEntry<TTable, TConfig>
        where TTable : BaseIndexTableConfig<TConfig>
        where TConfig : BaseIndexedConfig
    {
        [HideInInspector]
        [SerializeField] private int _index;

        public int Index => _index;
    }
}