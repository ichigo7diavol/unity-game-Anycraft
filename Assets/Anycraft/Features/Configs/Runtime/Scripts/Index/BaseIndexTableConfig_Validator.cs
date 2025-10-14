using FluentValidation;
using Anycraft.Features.Validation;

namespace Anycraft.Features.Configs.Index
{
    public abstract partial class BaseIndexTableConfig<TConfig> 
    {
        public new sealed class Validator
            : AbstractValidator<BaseIndexTableConfig<TConfig>>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                <
                    BaseSerializedConfig.Validator,
                    BaseSerializedConfig
                >());

                RuleFor(c => c._configs).NotNull();
            }
        }
    }
}