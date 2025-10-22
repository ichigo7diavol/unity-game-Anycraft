using FluentValidation;

namespace Anycraft.Features.Frame.Configs
{
    public abstract partial class BaseIndexTableEntry<TTable, TConfig>
    {
        public sealed class Validator
            : AbstractValidator<BaseIndexTableEntry<TTable, TConfig>>
        {
            public Validator()
            {
                RuleFor(c => c.Index)
                    .GreaterThanOrEqualTo(0);
            }
        }
    }
}