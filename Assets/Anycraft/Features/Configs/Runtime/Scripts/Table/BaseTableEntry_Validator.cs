using FluentValidation;

namespace Anycraft.Features.Configs
{
    public partial class BaseTableEntry<TTable, TConfig>
    {
        public sealed class Validator
            : AbstractValidator<BaseTableEntry<TTable, TConfig>>
        {
            public Validator()
            {
                RuleFor(c => c._id)
                    .NotNull()
                    .NotEmpty();
            }
        }
    }
}