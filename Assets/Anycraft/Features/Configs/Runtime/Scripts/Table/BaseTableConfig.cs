using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs.Table
{
    [UsedImplicitly]
    public abstract partial class BaseTableConfig<TConfig> : BaseSerializedConfig
        where TConfig : BaseSerializedConfig
    {
        public new sealed class Validator
        {
            public Validator()
            {
                
            }
        }

        [HideInInspector]
        [SerializeField] List<TConfig> _configs = new();

        public IReadOnlyList<TConfig> Configs => _configs;
    }
}

