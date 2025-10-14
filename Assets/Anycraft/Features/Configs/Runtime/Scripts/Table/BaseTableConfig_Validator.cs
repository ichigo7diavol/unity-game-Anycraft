using Anycraft.Features.Validation;
using FluentValidation;
using System.Linq;

namespace Anycraft.Features.Configs.Table
{
    public partial class BaseTableConfig<TConfig> 
    {
        public new sealed class Validator
            : AbstractValidator<BaseTableConfig<TConfig>>
        {
            public Validator()
            {
                Include(ValidatorCache.Get
                    <
                        BaseSerializedConfig.Validator,
                        BaseSerializedConfig
                    >());

                RuleFor(c => c._configs)
                    .Must(c => c.Select(config => config.Id).Distinct().Count() == c.Count)
                    .WithMessage("Must containe unique key values");
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow
            <
                Validator,
                BaseTableConfig<TConfig> 
            >();
        }
    }
}

