using Anycraft.FluentValidationExtensions.Configs;
using Anycraft.FluentValidationExtensions.Validation;
using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Inventory.Configs
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