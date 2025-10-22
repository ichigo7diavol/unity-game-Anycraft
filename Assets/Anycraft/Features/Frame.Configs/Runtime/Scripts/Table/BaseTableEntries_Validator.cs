using FluentValidation;
using System.Linq;

namespace Anycraft.Features.Frame.Configs
{
    public abstract partial class BaseTableEntries<TTable, TConfig> 
    {
        public sealed class Validator
            : AbstractValidator<BaseTableEntries<TTable, TConfig>>
        {
            public Validator()
            {
                RuleFor(c => c._ids)
                    .NotNull();

                RuleForEach(c => c._ids)
                    .NotNull();
                
                RuleForEach(c => c._ids)
                    .Custom
                    (
                        (value, context) =>
                        {
                            if (value == null)
                            {
                                return;
                            }
                            var configs = context.InstanceToValidate._ids;

                            if (configs.Count(c => c != null && c == value) >= 2)
                            {
                                context.AddFailure($"duplicated id '{value}'");
                            }
                        }
                    );
            }
        }
    }
}