using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs
{
    [UsedImplicitly]
    public abstract partial class BaseTableConfig<TConfig> : BaseSerializedConfig
        where TConfig : BaseIdentifiableConfig
    {
        [HideInInspector]
        [SerializeField] List<TConfig> _configs = new();

        public IReadOnlyList<TConfig> Configs => _configs;
    }
}

