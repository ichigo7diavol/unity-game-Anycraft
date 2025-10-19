using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using Anycraft.Features.FluentValidationExtensions;

namespace Anycraft.Features.Configs.Index
{
    [UsedImplicitly]
    public abstract partial class BaseIndexTableConfig<TConfig> 
        : BaseSerializedConfig
        where TConfig : BaseIndexedConfig
    {
        [HideInInspector]
        [SerializeField] private List<TConfig> _configs = new();

        public IEnumerable<TConfig> Configs => _configs;

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                Validator,
                BaseIndexTableConfig<TConfig>       
            >();
        }
    }
}