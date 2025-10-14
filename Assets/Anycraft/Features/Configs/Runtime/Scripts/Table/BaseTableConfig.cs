using System.Collections.Generic;
using Anycraft.Features.Validation;
using FluentValidation;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs.Table
{
    [UsedImplicitly]
    public abstract partial class BaseTableConfig<TConfig> : BaseSerializedConfig
        where TConfig : BaseSerializedConfig
    {
        public new sealed class Validator
            : AbstractValidator<BaseTableConfig<TConfig>>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseSerializedConfig.Validator,
                    BaseSerializedConfig>());
            }
        }

        [HideInInspector]
        [SerializeField] List<TConfig> _configs = new();

        public IReadOnlyList<TConfig> Configs => _configs;
    }
}

