using FluentValidation;
using Anycraft.Features.FluentValidationExtensions;
using System.Linq;

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

                RuleFor(c => c._configs)
                    .NotNull();

                RuleForEach(c => c._configs)
                    .NotNull();
                
                RuleForEach(c => c._configs)
                    .Custom
                    (
                        (value, context) =>
                        {
                            if (value == null)
                            {
                                return;
                            }
                            var configs = context.InstanceToValidate.Configs;

                            if (configs.Count(c => c.Index == value.Index) >= 2)
                            {
                                context.AddFailure($"duplicated key '{value.Id}'");
                            }
                        }
                    );
            }
        }
    }
}