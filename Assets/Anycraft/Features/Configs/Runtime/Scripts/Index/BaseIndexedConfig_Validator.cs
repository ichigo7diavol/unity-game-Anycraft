using Anycraft.FluentValidationExtensions.Validation;
using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Configs.Index
{
    public abstract partial class BaseIndexedConfig
    {
        public new sealed class Validator
            : AbstractValidator<BaseIndexedConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                <
                    BaseSerializedConfig.Validator,
                    BaseSerializedConfig
                >());

                RuleFor(c => c.Index)
                    .GreaterThanOrEqualTo(0);
            }
        }
    }
}