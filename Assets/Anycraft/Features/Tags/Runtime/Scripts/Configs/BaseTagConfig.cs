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
                Include(ValidatorCache.Get<BaseSerializedConfig>());
            }
        }

        [Serializable]
        public sealed class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private LocalizationData _localization;

        public LocalizationData Localization { get => _localization; }

        public override string ToString() => $"Tag--{Id}";
    }
}

