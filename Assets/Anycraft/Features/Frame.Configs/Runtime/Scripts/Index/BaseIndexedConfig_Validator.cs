using Anycraft.Features.Extensions.FluentValidation;
using FluentValidation;

namespace Anycraft.Features.Frame.Configs
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