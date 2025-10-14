using Anycraft.Features.Tags.Configs;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemTagConfig))]
    public sealed class ItemTagConfig : BaseTagConfig
    {
        public new sealed class Validator
            : AbstractValidator<ItemTagConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseTagConfig.Validator, BaseTagConfig>());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow<Validator, ItemTagConfig>();
        }
    }
}

