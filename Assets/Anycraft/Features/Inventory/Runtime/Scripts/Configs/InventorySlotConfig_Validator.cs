using Anycraft.Features.Configs;
using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Inventory.Configs
{
    public sealed partial class InventorySlotConfig
    {
        public new sealed class Validator
            : AbstractValidator<InventorySlotConfig>
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
                BaseSerializedConfig.Validator,
                BaseSerializedConfig
            >();
        }
    }
}