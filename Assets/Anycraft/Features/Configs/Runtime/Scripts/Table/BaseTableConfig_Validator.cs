using Anycraft.FluentValidationExtensions.Validation;
using FluentValidation;
using System.Linq;

namespace Anycraft.FluentValidationExtensions.Configs.Table
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

                            if (configs.Count(c => c != null && c.Id == value.Id) >= 2)
                            {
                                context.AddFailure($"duplicated key '{value.Id}'");
                            }
                        }
                    );
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

