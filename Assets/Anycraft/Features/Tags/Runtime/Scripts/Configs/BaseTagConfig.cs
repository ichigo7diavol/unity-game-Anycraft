using System;
using Anycraft.Features.Configs;
using Anycraft.Features.Localization;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Tags.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Frame/Tags/Configs/" + nameof(BaseTagConfig))]
    public abstract class BaseTagConfig : BaseSerializedConfig
    {
        public new sealed class Validator
            : AbstractValidator<BaseTagConfig>
        {
            public Validator()
            {
            }
        }

        [Serializable]
        public sealed class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private LocalizationData _localization;

        public LocalizationData Localization { get => _localization; }

        public override string ToString() => $"Tag--{Id}"; 
    
        public override void Validate()
        {
            this.ValidateAndThrow(new Validator());
        }
    }
}

