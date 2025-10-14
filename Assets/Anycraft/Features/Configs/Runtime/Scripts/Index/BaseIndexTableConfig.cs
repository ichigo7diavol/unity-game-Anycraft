using UnityEngine;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Anycraft.Features.Configs.Index
{
    [Serializable]
    [UsedImplicitly]
    public abstract partial class BaseIndexTableConfig<TConfig> 
        : BaseSerializedConfig
        where TConfig : BaseIndexedConfig
    {
        [HideInInspector]
        [SerializeField] private List<TConfig> _configs = new();

        public IEnumerable<TConfig> Configs => _configs;
    }
}