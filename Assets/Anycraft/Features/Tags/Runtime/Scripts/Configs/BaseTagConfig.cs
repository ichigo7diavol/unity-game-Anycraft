using System;
using Anycraft.Features.Configs;
using Anycraft.Features.Localization;
using Anycraft.Features.Validation;
using FluentValidation;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Tags.Configs
{
    [UsedImplicitly]
    public abstract class BaseTagConfig
        : BaseSerializedConfig
    {
        public new sealed class Validator
            : AbstractValidator<BaseTagConfig>
        {
            public Validator()
            {
                var validator = ValidatorCache.Get<
                    BaseSerializedConfig.Validator, BaseSerializedConfig>();
                
                Include(validator);
            }
        }

        public override string ToString() => $"Tag--{Id}";
    }
}

