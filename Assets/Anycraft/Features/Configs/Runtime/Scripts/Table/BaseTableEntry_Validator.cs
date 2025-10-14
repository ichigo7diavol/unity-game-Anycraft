using FluentValidation;

namespace Anycraft.Features.Configs.Table
{
    public partial class BaseTableEntry<TTable, TConfig>
    {
        public sealed class Validator
            : AbstractValidator<BaseTableEntry<TTable, TConfig>>
        {
            public Validator()
            {
                RuleFor(x => x._id)
                    .NotNull()
                    .NotEmpty();
            }
        }
    }
}