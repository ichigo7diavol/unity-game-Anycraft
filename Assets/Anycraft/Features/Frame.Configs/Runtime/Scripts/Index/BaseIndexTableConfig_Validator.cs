using FluentValidation;
using System.Linq;
using Anycraft.Features.Extensions.FluentValidation;

namespace Anycraft.Features.Frame.Configs
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
                                context.AddFailure($"duplicated index '{value.Index}'");
                            }
                        }
                    );
            }
        }
    }
}