using Anycraft.Features.Configs;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Resource.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Resource/" + nameof(ResourceConfig))]
    public sealed class ResourceConfig
        : BaseSerializedConfig
    {
        public new sealed class Validator
            : AbstractValidator<ResourceConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseSerializedConfig>());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow();
        }
    }
}