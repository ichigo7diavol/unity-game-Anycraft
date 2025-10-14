using Anycraft.Features.Tags.Configs;
using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Items.Configs
{
    public sealed partial class ItemTagConfig
    {
        public new sealed class Validator
            : AbstractValidator<ItemTagConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                <
                    BaseTagConfig.Validator,
                    BaseTagConfig
                >());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                BaseTagConfig.Validator,
                BaseTagConfig
            >();
        }
    }
}

