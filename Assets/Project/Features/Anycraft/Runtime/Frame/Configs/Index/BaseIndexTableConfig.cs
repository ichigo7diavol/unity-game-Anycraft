using UnityEngine;
using System;
using System.Collections.Generic;

namespace Anycraft.Frame.Configs.Index
{
    [Serializable]
    public abstract partial class BaseIndexTableConfig<TConfig> : BaseSerializedConfig
        where TConfig : BaseIndexedConfig
    {
        [HideInInspector]
        [SerializeField] private List<TConfig> _configs = new();

        public IEnumerable<TConfig> Configs => _configs;
    }
}