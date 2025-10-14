using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Configs.Table
{
    [UsedImplicitly]
    public abstract partial class BaseTableConfig<TConfig> : BaseSerializedConfig
        where TConfig : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] List<TConfig> _configs = new();

        public IReadOnlyList<TConfig> Configs => _configs;
    }
}

