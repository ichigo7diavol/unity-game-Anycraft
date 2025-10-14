using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Configs.Index
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
            }
        }
    }
}