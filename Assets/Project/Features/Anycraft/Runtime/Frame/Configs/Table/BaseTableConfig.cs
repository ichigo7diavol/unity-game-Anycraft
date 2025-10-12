using System.Collections.Generic;
using UnityEngine;

namespace Anycraft.Frame.Configs.Table
{
    public abstract partial class BaseTableConfig<TConfig> : SerializedConfig
        where TConfig : SerializedConfig
    {
        [HideInInspector]
        [SerializeField] List<TConfig> _configs = new();

        public IReadOnlyList<TConfig> Configs => _configs;

        public override bool Validate(ref string errorMessage)
        {
            return true;
        }
    }
}

