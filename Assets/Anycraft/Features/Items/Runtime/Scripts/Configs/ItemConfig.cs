using System;
using Anycraft.Features.Configs;
using Anycraft.Features.Localization;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemConfig))]
    public sealed class ItemConfig : BaseSerializedConfig
    {
        public new sealed class Validator
            : AbstractValidator<ItemConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseSerializedConfig.Validator,
                    BaseSerializedConfig>());
            }
        }

        [Serializable]
        public sealed class LocalizationData : BaseLocalizationData
        {
        }

        [SerializeField] private ItemTagTableEntries _tags;

        public override void Validate()
        {
            this.ValidateAndThrow<Validator, ItemConfig>();
        }
    }
}

