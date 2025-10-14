using Anycraft.Features.Configs;
using Anycraft.Features.FluentValidationExtensions;
using FluentValidation;

namespace Anycraft.Features.Inventory.Configs
{
    public sealed partial class InventoryConfig
    {
        public new sealed class Validator
            : AbstractValidator<InventoryConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                <
                    BaseSerializedConfig.Validator,
                    BaseSerializedConfig
                >());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                Validator,
                InventoryConfig
            >();
        }
    }
}