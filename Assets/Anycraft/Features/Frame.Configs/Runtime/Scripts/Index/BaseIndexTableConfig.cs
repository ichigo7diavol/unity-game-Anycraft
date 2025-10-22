using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using Anycraft.Features.Extensions.FluentValidation;

namespace Anycraft.Features.Frame.Configs
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