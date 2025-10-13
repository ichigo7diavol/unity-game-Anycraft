using UnityEngine;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Anycraft.Features.Configs.Index
{
    [Serializable]
    [UsedImplicitly]
    public abstract partial class BaseIndexTableConfig<TConfig> : BaseSerializedConfig
        where TConfig : BaseIndexedConfig
    {
        public new sealed class Validator
        {
            public Validator()
            {

            }
        }
        
        [HideInInspector]
        [SerializeField] private List<TConfig> _configs = new();

        public IEnumerable<TConfig> Configs => _configs;
    }
}